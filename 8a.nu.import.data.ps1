function Get-AscentList {
    param(
        $Session,

        [string]
        $CragName,

        [int]
        $AscentType = 1
    )

    $response = Invoke-WebRequest `
        -Uri "https://www.8a.nu/scorecard/Ticklist.aspx?CragName=$CragName&AscentType=$AscentType" `
        -WebSession $Session
}

function Get-SpanInnerText {
    param(
        $Html,
        $SpanId
    )

    $regexPattern = "<span [^>]*id=(`"|')$SpanId(`"|')>(?<innerText>.*?)</span>"

    $regEx = New-Object System.Text.RegularExpressions.Regex `
        $regexPattern, `
        ([System.Text.RegularExpressions.RegexOptions]::Singleline -bor [System.Text.RegularExpressions.RegexOptions]::Compiled)

    $match = $regEx.Match($Html)
    $result = ""

    if ($match.Success) {
        $result = $match.Groups['innerText'].Value -replace "<.*>"
        $result = [System.Web.HttpUtility]::HtmlDecode($result)
    }

    Write-Output $result
}

function Get-Regions {
    param(
        $Session
    )

    Write-Progress -Activity "Importing regions from csv"

    $regions = Import-Csv `
        -Delimiter '$' `
        -Path 'D:\_projects\climbing-guide-api\8a.nu.regions.csv' `
        -Header @('Position', 'Id', 'Name', 'Ascents')

    $fileStream = [System.IO.File]::Open(
        'D:\_projects\climbing-guide-api\8a.nu.regions.exported.csv',
        [System.IO.FileMode]::Create)
    $writer = New-Object System.IO.StreamWriter $fileStream
    $writer.Write("{`"regions`":[")

    Write-Progress -Activity "Importing regions finished successfully" -Completed
    Write-Progress -Activity "Getting regions info" -Id 1

    $current = 0
    $total = $regions.Count

    Add-Type -AssemblyName System.Web

    # The disks are processed in parallel.
    $regions | % {

        $regionResponse = Invoke-WebRequest `
            -Uri "https://www.8a.nu/crags/Crag.aspx?CragId=$($_.Id)" `
            -WebSession $Session `
            -UseBasicParsing

        $name = Get-SpanInnerText -Html $regionResponse.Content -SpanId 'ctl00_ContentPlaceholder_LabelCragName'
        $country = Get-SpanInnerText -Html $regionResponse.Content -SpanId 'ctl00_ContentPlaceholder_LabelCragCountry'
        $access = Get-SpanInnerText -Html $regionResponse.Content -SpanId 'ctl00_ContentPlaceholder_LabelAccessInfo'
        $info = Get-SpanInnerText -Html $regionResponse.Content -SpanId 'ctl00_ContentPlaceholder_LabelInfoDesc'
        $city = Get-SpanInnerText -Html $regionResponse.Content -SpanId 'ctl00_ContentPlaceholder_LabelCragCity'

        $posParts = $_.Position.Replace('[', '').Replace(']', '').Split(',')

        $regionData = New-Object PSObject -Property @{
            Id = $_.Id;
            Name = $name;
            Position = @([double]$posParts[0], [double]$posParts[1]);
            Info = $info;
            Access = $access;
            Country = $country;
            City = $city
            Ascents = $_.Ascents;
        }

        $json = ConvertTo-Json -InputObject $regionData -Compress
        $writer.Write("$json,")

        $counter += 1
        $progressPercent = ($counter / $total) * 100

        Write-Progress `
            -Activity "Getting regions info" `
            -Status "Region $name details retrieved" `
            -PercentComplete $progressPercent
    }
    Write-Progress -Activity "Getting regions info" -Id 1 -Completed
    $writer.Write("]}")
    $writer.Close()
}

function Get-EightASession {
    param(
        $Username,
        $Password
    )

    Write-Progress -Activity "Getting session"

    # get asp.net form values
    $loginForm = Invoke-WebRequest `
        -Uri "https://www.8a.nu/" `
        -SessionVariable 'Session'

    $eventValidationValue = ($loginForm.InputFields | ? { $_.id -eq '__EVENTVALIDATION' }).value
    $viewStateValue = ($loginForm.InputFields | ? { $_.id -eq '__VIEWSTATE' }).value
    $viewGeneratorValue = ($loginForm.InputFields | ? { $_.id -eq '__VIEWSTATEGENERATOR' }).value

    $postParams = @{
    '__EVENTVALIDATION'	= $eventValidationValue;
    '__VIEWSTATE' =	$viewStateValue;
    '__VIEWSTATEGENERATOR' = $viewGeneratorValue;
    'ctl00$LeftControl$ctl01$ButtonLogin'= 'Login';
    'ctl00$LeftControl$ctl01$CheckBoxSave' = 'on';
    'ctl00$LeftControl$ctl01$TextBoxId' = $Username;
    'ctl00$LeftControl$ctl01$TextBoxPassword' = $Password;
    }

    # login
    $loginResponse = Invoke-WebRequest `
        -Method Post `
        -Uri "https://www.8a.nu/" `
        -WebSession $Session `
        -Body $postParams

    Write-Progress -Activity "Session aquired successfully" -Completed

    Write-Output $Session
}

function New-Regions {
    param()

    $reader = New-Object System.IO.StreamReader('D:\_projects\climbing-guide-api\8a.nu.regions.exported.csv')

    while (($line = $reader.ReadLine()) -ne $null) {
        $region = ConvertFrom-Csv `
            -InputObject $line `
            -Delimiter '/' `
            -Header @('Ascents', 'Id', 'Access', 'Info', 'Name', 'Country', 'City', 'Position')

        Write-Host $region.Name
    }

    $reader.Close()
}

$Session = Get-EightASession -Username 'crawler@mailhex.com' -Password 'crawler8a'
Get-Regions -Session $Session

# New-Regions

Write-Host Ready