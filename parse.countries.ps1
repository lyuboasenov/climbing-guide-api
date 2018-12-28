$csv = Import-Csv '.\coutry.codes.csv' -Encoding UTF8
$csvLocations = Import-Csv '.\coutry.locations.csv' -Encoding UTF8
$result = @()

$csv | % {
    $country = $_
    $location = ($csvLocations | ? { $_.code -eq $country.'alpha-2' })
    $country | Add-Member -NotePropertyName latitude -NotePropertyValue $location.latitude
    $country | Add-Member -NotePropertyName longitude -NotePropertyValue $location.longitude
    $result += $country
}

$result | Export-csv 'country.code.location.csv'

$result | % {
    $payload = @{
        'code_2' = $_.'alpha-2';
        'code_3' = $_.'alpha-3';
        'name' = $_.name;
        'region' = $_.region;
        'sub_region' = $_.'sub-region';
        'intermediate_region' = $_.'intermediate-region';
        'latitude' = [double]$_.latitude;
        'longitude' = [double]$_.longitude;
    } | ConvertTo-Json

    Try {
    $response = Invoke-WebRequest `
        -Uri 'http://127.0.0.1:8000/countries' `
        -Method Post `
        -Headers @{
            "Accept"="application/json"
            "X-CSRFToken"="RD7NsZ66HHnxQNqJBPnF3Ifb9BDHBm2N0D7Vu6LCBhYJoxS41isxf2V7OYBKu4Zx"
            "Content-Type"="application/json"
        } `
        -Body ([System.Text.Encoding]::UTF8.GetBytes($payload)) `
        -UseBasicParsing
    } Catch {
        Write-Error $payload
    }
}
