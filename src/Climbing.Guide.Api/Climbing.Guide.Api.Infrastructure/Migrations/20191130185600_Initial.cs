using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Climbing.Guide.Api.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    Code2 = table.Column<string>(maxLength: 2, nullable: false),
                    Code3 = table.Column<string>(maxLength: 3, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Location_Latitude = table.Column<double>(nullable: true),
                    Location_Longitude = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    ParentId = table.Column<string>(nullable: true),
                    CountryId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Info = table.Column<string>(type: "ntext", nullable: true),
                    Approach = table.Column<string>(type: "ntext", nullable: true),
                    Descent = table.Column<string>(type: "ntext", nullable: true),
                    History = table.Column<string>(type: "ntext", nullable: true),
                    Ethics = table.Column<string>(type: "ntext", nullable: true),
                    Accomodations = table.Column<string>(type: "ntext", nullable: true),
                    Restrictions = table.Column<string>(type: "ntext", nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<string>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    UpdatedById = table.Column<string>(nullable: true),
                    ApprovedOn = table.Column<DateTime>(nullable: true),
                    ApprovedById = table.Column<string>(nullable: true),
                    Location_Latitude = table.Column<double>(nullable: true),
                    Location_Longitude = table.Column<double>(nullable: true),
                    Revision = table.Column<int>(nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Area_Users_ApprovedById",
                        column: x => x.ApprovedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Area_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Area_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Area_Area_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Area",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Area_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<string>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    UpdatedById = table.Column<string>(nullable: true),
                    ApprovedOn = table.Column<DateTime>(nullable: true),
                    ApprovedById = table.Column<string>(nullable: true),
                    Location_Latitude = table.Column<double>(nullable: true),
                    Location_Longitude = table.Column<double>(nullable: true),
                    AreaId = table.Column<string>(nullable: true),
                    Difficulty = table.Column<double>(nullable: false),
                    Rating = table.Column<float>(nullable: false),
                    Length = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Info = table.Column<string>(type: "ntext", nullable: true),
                    Approach = table.Column<string>(type: "ntext", nullable: true),
                    History = table.Column<string>(type: "ntext", nullable: true),
                    Type = table.Column<int>(nullable: false),
                    ConcurrencyToken = table.Column<byte[]>(nullable: true),
                    Revision = table.Column<int>(nullable: false),
                    RouteId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Routes_Users_ApprovedById",
                        column: x => x.ApprovedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Routes_Area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Area",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Routes_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Routes_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Routes_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SchemaPoint",
                columns: table => new
                {
                    RouteId = table.Column<string>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    X = table.Column<double>(nullable: false),
                    Y = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchemaPoint", x => new { x.RouteId, x.Id });
                    table.ForeignKey(
                        name: "FK_SchemaPoint_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code2", "Code3", "Name" },
                values: new object[,]
                {
                    { "9235cd70-220e-47d9-b76e-17a81d1db7f5", "AF", "AFG", "Afghanistan" },
                    { "9eb55e10-f386-4d0e-9d3f-6e763970dbec", "NG", "NGA", "Nigeria" },
                    { "52849ef9-6ad6-4f4c-bbca-98a841736311", "NU", "NIU", "Niue" },
                    { "2e6970b6-d5dd-4589-ba8b-393dae6aadc6", "NF", "NFK", "Norfolk Island" },
                    { "56998bee-caeb-4f2b-ae60-51de18e7d744", "MP", "MNP", "Northern Mariana Islands" },
                    { "497497c7-c13d-40bf-bda6-8cfe8efc1068", "NO", "NOR", "Norway" },
                    { "1b8259c4-eef8-4ac2-bcea-6e0d46d5bc42", "OM", "OMN", "Oman" },
                    { "93605d6b-a2ba-4d7a-bb51-8acb08e5bd1a", "PK", "PAK", "Pakistan" },
                    { "9f6d3e75-cd21-409f-9173-aca90f9b93f3", "PW", "PLW", "Palau" },
                    { "9feb70b9-80a2-4b12-96ea-62d423af00f0", "PS", "PSE", "Palestine, State of" },
                    { "9ef3163e-a0b7-4967-ae61-a87b5b5c19bc", "PA", "PAN", "Panama" },
                    { "33084585-3273-46ca-8fc7-b169f03dd1b8", "PG", "PNG", "Papua New Guinea" },
                    { "33edd49d-df1c-40c0-a098-4a5c369e23a3", "PY", "PRY", "Paraguay" },
                    { "57eedc31-71b7-44bc-aca0-2b3ff9e64361", "PE", "PER", "Peru" },
                    { "ec195e19-a5f9-4ab3-a0d7-50174fb14dc8", "PH", "PHL", "Philippines" },
                    { "dd1095a3-0b66-41ae-a3ba-2f415b7839b2", "PN", "PCN", "Pitcairn" },
                    { "13e332cd-aa81-410d-b18c-ad95b6b13663", "PL", "POL", "Poland" },
                    { "5e288331-46de-49f9-a1be-896fb4e5cffa", "PT", "PRT", "Portugal" },
                    { "73a60e18-9dbe-4f74-8353-5c5568e572c8", "PR", "PRI", "Puerto Rico" },
                    { "bcd0422f-1de7-4e28-aa0f-08df50134a83", "QA", "QAT", "Qatar" },
                    { "39ab367c-b9e6-46a3-be15-132677ab2ab3", "RE", "REU", "Réunion" },
                    { "325b9be0-826c-432a-aacc-4a8db883567f", "RE", "REU", "Reunion" },
                    { "4b2947f4-4d12-47c3-9d57-a8ba8df11ccb", "RO", "ROU", "Romania" },
                    { "f4830d35-f82d-4d0a-889c-7500e6e40973", "RU", "RUS", "Russian Federation" },
                    { "e8fe4d7a-f640-4c2f-8de2-dd64552074cb", "RU", "RUS", "Russia" },
                    { "5387a1a4-d6ae-43cd-b343-e5f2be6af1ea", "RW", "RWA", "Rwanda" },
                    { "54478e1d-a6b7-4c1c-97c1-4d82ede303f6", "BL", "BLM", "Saint Barthélemy" },
                    { "f370ac01-e25a-460a-b95e-fb4e97180f5c", "SH", "SHN", "Saint Helena, Ascension and Tristan da Cunha" },
                    { "906fd092-01ed-40a7-a01e-6f51dd72762d", "KN", "KNA", "Saint Kitts and Nevis" },
                    { "3a70a768-03fc-4870-9509-9275ab7110b0", "LC", "LCA", "Saint Lucia" },
                    { "6a80d61b-344f-4cd0-84b1-d8df1d447fde", "NE", "NER", "Niger" },
                    { "b515fcf8-601b-4464-89dd-1c1e5d7a1098", "NI", "NIC", "Nicaragua" },
                    { "553af18b-f5a7-4d8d-aa77-573297891ad8", "NZ", "NZL", "New Zealand" },
                    { "c9333810-a097-4a75-b0c5-afd22f6863c4", "NC", "NCL", "New Caledonia" },
                    { "c5a72efb-9905-4de0-9ab7-b599aced788d", "LT", "LTU", "Lithuania" },
                    { "1dedcb24-ffce-4294-93c5-514d66fba942", "LU", "LUX", "Luxembourg" },
                    { "0015a40a-a493-41e2-aebe-cbccd867c68c", "MO", "MAC", "Macao" },
                    { "67ef12fb-6c70-4763-bfc6-34575cfd6012", "MK", "MKD", "Macedonia (the former Yugoslav Republic of)" },
                    { "c694b105-20f7-49ae-b621-86d06de1a29c", "MK", "MKD", "Macedonia" },
                    { "3ca9a491-009d-4432-9551-6a52e97c9b21", "MG", "MDG", "Madagascar" },
                    { "6cb29817-ac30-43af-a691-7e6220b3d415", "MW", "MWI", "Malawi" },
                    { "5ca6b9d9-1c11-4b6c-b2b3-00a067ca3bb1", "MY", "MYS", "Malaysia" },
                    { "bfafec54-ee78-4e3c-8fb0-d677c6420ed4", "MV", "MDV", "Maldives" },
                    { "ea98b43b-379b-4860-862e-b3876b23ee08", "ML", "MLI", "Mali" },
                    { "c54afedf-fe46-49cb-baca-53ec0892d4a5", "MT", "MLT", "Malta" },
                    { "e3385e5e-b497-4121-8c58-5f974f47f598", "MH", "MHL", "Marshall Islands" },
                    { "f71999a7-0183-41b1-af60-28cae942e45e", "MQ", "MTQ", "Martinique" },
                    { "32585d9f-0bfa-4b0d-b28a-6633fc9e2a57", "MR", "MRT", "Mauritania" },
                    { "192f49dc-d414-4c45-9b3c-8d90b3f394ee", "MF", "MAF", "Saint Martin (French part)" },
                    { "8e750165-45d0-4608-9fe0-fffcd0b497ac", "MU", "MUS", "Mauritius" },
                    { "ab87ae59-f9c7-4fce-bf2d-21895e0337d4", "MX", "MEX", "Mexico" },
                    { "59d96296-7a8c-41e2-9288-e38280542bd9", "FM", "FSM", "Micronesia (Federated States of)" },
                    { "463b405f-7d27-4e31-88d0-f66c7e5a08c1", "MD", "MDA", "Moldova (Republic of)" },
                    { "6220e302-7f3e-4c65-921d-b570b0da87be", "MC", "MCO", "Monaco" },
                    { "8f1fb492-938a-4e4b-80b1-00588acb1ba5", "MN", "MNG", "Mongolia" },
                    { "d1e98f47-be26-491f-a345-ba094b0d09c7", "ME", "MNE", "Montenegro" },
                    { "7694799d-5d0a-4131-a84b-72b74ed6992f", "MS", "MSR", "Montserrat" },
                    { "eedb87e3-450d-485b-b285-9b222bd2228c", "MA", "MAR", "Morocco" },
                    { "66556adb-f36c-471b-917f-fce7cc573b24", "MZ", "MOZ", "Mozambique" },
                    { "e366c7a4-1622-42b8-91ec-eb08e05c9e5d", "MM", "MMR", "Myanmar" },
                    { "e4c7f11c-6e2c-426f-9a43-a7390788393f", "NA", "NAM", "Namibia" },
                    { "ad87db55-a77a-4896-af59-15bf504c1af0", "NR", "NRU", "Nauru" },
                    { "f00a13db-1aca-42d7-a10c-02a0a88cdf80", "NP", "NPL", "Nepal" },
                    { "d7b4a62a-e4bf-4ea7-ab68-87c8fadfa0d6", "NL", "NLD", "Netherlands" },
                    { "deedbc18-ece9-49e7-b9c8-45721cc6c044", "YT", "MYT", "Mayotte" },
                    { "f162f8fa-ab82-43ef-9e98-f57d879d2ea2", "LI", "LIE", "Liechtenstein" },
                    { "2355a54e-a7f4-4318-871a-38d6edd75207", "PM", "SPM", "Saint Pierre and Miquelon" },
                    { "7f2d7293-2403-45d6-90c0-509842bc1692", "WS", "WSM", "Samoa" },
                    { "c82f03a5-bd89-44a3-87a8-41984e723e38", "TK", "TKL", "Tokelau" },
                    { "6bb35bfd-1af5-4d98-a308-0c4824241a47", "TO", "TON", "Tonga" },
                    { "9cba9cc9-9b55-4407-8158-86c3de455e3c", "TT", "TTO", "Trinidad and Tobago" },
                    { "c805b9a0-9069-4142-a30f-314582da3b7b", "TN", "TUN", "Tunisia" },
                    { "a49e3fb1-f5dd-4ac3-bd2a-586fd3bca53c", "TR", "TUR", "Turkey" },
                    { "847ce96d-7f00-4abb-95f5-8d89887deed8", "TM", "TKM", "Turkmenistan" },
                    { "ca709869-c458-4688-b190-903d7bf65e69", "TC", "TCA", "Turks and Caicos Islands" },
                    { "8b659753-4d5c-42d5-891c-5a52f5f85e64", "TV", "TUV", "Tuvalu" },
                    { "d19bc0f6-bb76-4816-a27f-85258169e92b", "UG", "UGA", "Uganda" },
                    { "b93dca51-d727-442d-ad20-f72e435998a8", "UA", "UKR", "Ukraine" },
                    { "ba49c51b-7e06-4539-ad8b-3f8be3bec319", "AE", "ARE", "United Arab Emirates" },
                    { "92892d5c-732e-48eb-97fa-f0d95670b66b", "GB", "GBR", "United Kingdom of Great Britain and Northern Ireland" },
                    { "ec91b935-16a3-46b9-8d8b-a35720331fd5", "GB", "GBR", "United Kingdom" },
                    { "844cd310-c633-4077-a629-af5c23207319", "US", "USA", "United States of America" },
                    { "97dcd74c-1d3d-4833-bd22-55a67546d067", "US", "USA", "United States" },
                    { "975e01db-ab12-442c-ba1f-3b424265958d", "UM", "UMI", "United States Minor Outlying Islands" },
                    { "0e66ebff-f321-4e8e-a9b7-0aa4e59a80c2", "UY", "URY", "Uruguay" },
                    { "dc17bfac-fc2d-4f3d-8036-111d9de681f5", "UZ", "UZB", "Uzbekistan" },
                    { "af4e5c94-b79a-431b-a9e8-23688bbeda03", "VU", "VUT", "Vanuatu" },
                    { "31f99f96-c345-4a13-8639-bf716ac9c104", "VE", "VEN", "Venezuela (Bolivarian Republic of)" },
                    { "32aa5036-4cbf-472e-97af-201f143b14bf", "VE", "VEN", "Venezuela" },
                    { "b95674d5-f7de-4238-aba9-5ba8d6b0a742", "VN", "VNM", "Viet Nam" },
                    { "103da448-ca0a-46f9-8c47-aacc7777c552", "VG", "VGB", "Virgin Islands (British)" },
                    { "c30b17c1-5289-49c8-84e2-d3fdd839be1c", "VG", "VGB", "Virgin Isles (British)" },
                    { "44bc7a2e-aeeb-45d3-b6da-b2620e75ac9f", "VI", "VIR", "Virgin Islands (U.S.)" },
                    { "447b16f1-4894-420c-ba88-b8583ccec770", "WF", "WLF", "Wallis and Futuna" },
                    { "7adc80bf-e289-4f2f-88fe-f207d8f9feba", "EH", "ESH", "Western Sahara" },
                    { "2bfa8436-4ad3-4d2f-a4c1-85c990b2e57f", "YE", "YEM", "Yemen" },
                    { "bc262cbe-39da-455f-9249-e421e0038442", "ZM", "ZMB", "Zambia" },
                    { "7cb25e94-cbe0-46a4-8f46-b7ae5cd06312", "TG", "TGO", "Togo" },
                    { "f78fb1e7-1322-4f77-a166-7d78776f35db", "TL", "TLS", "Timor-Leste" },
                    { "9cfd90ea-1001-441c-aa9a-6bfbfc3a1b63", "TH", "THA", "Thailand" },
                    { "88fccb28-b38e-4093-b2e6-b2790ec01e95", "TZ", "TZA", "Tanzania, United Republic of" },
                    { "68b82b62-fbdc-4ba3-8077-db71f2c8a249", "SM", "SMR", "San Marino" },
                    { "b0d1a2c9-16b7-445d-8dc9-c1c1ec13d561", "ST", "STP", "Sao Tome and Principe" },
                    { "37e82658-5623-497e-aad4-9a62d8912f3b", "SA", "SAU", "Saudi Arabia" },
                    { "f3bbbf8f-b177-4a1a-94f3-c333a5c11391", "SN", "SEN", "Senegal" },
                    { "0806405a-df0b-45a6-8613-788a1af3c621", "RS", "SRB", "Serbia" },
                    { "b5a0b813-c87a-48da-a4a6-8230e9e6bd52", "RS", "SRB", "Serbia (Yugoslavia)" },
                    { "7990469e-7444-4b2b-8b0c-e5370e088840", "SC", "SYC", "Seychelles" },
                    { "023fa312-2e64-448c-a3c3-2f819f15acba", "SL", "SLE", "Sierra Leone" },
                    { "ed4e10a8-3a3d-4651-9f1a-3d51d07b9ab7", "SG", "SGP", "Singapore" },
                    { "e9924300-87ab-41ab-a182-7813e3875c4a", "SX", "SXM", "Sint Maarten (Dutch part)" },
                    { "0ac58dff-6627-46b3-aea9-b80e90155804", "SK", "SVK", "Slovakia" },
                    { "48aaaf32-beb2-4923-9aaa-4c95370b9252", "SI", "SVN", "Slovenia" },
                    { "0e51bcfc-47f4-4488-ac1e-06c6cf4e2b80", "SB", "SLB", "Solomon Islands" },
                    { "d906ae67-c0fe-4f92-b876-a746aaa8bca0", "SO", "SOM", "Somalia" },
                    { "b582ecd6-a1cf-427d-8bb8-042e0e0aed87", "VC", "VCT", "Saint Vincent and the Grenadines" },
                    { "8e4a3dd7-b653-4c95-b450-b8bddb9d6dad", "ZA", "ZAF", "South Africa" },
                    { "6ceb040a-7570-421d-b75f-152cdbe20a19", "SS", "SSD", "South Sudan" },
                    { "d1f3c06a-280a-4e36-a6d0-5d80a3c7ac2d", "ES", "ESP", "Spain" },
                    { "2e940e72-d23a-48ff-9c3c-811610b1556e", "ES", "ESP", "España" },
                    { "92ea4afd-0bd6-4fb4-a984-3ea66497462c", "LK", "LKA", "Sri Lanka" },
                    { "d56e076c-0143-41b0-868b-4a9dc7e5a062", "SD", "SDN", "Sudan" },
                    { "87a92f9a-3b31-45a9-8ff5-06f1b063d0a3", "SR", "SUR", "Suriname" },
                    { "29e60779-dd75-4484-b510-81a6ef1575c7", "SJ", "SJM", "Svalbard and Jan Mayen" },
                    { "c25570bd-0810-4872-9c04-86c0ef0ba2c7", "SE", "SWE", "Sweden" },
                    { "17779450-4593-4630-a455-0c0f84fb703b", "CH", "CHE", "Switzerland" },
                    { "3b2540c5-cc80-48b9-aeb3-d53195ecba11", "SY", "SYR", "Syrian Arab Republic" },
                    { "355fba98-4348-4988-aae6-e327fa3929ac", "SY", "SYR", "Syria" },
                    { "57f0c3c3-673d-49e1-b883-93b08b514c8a", "TW", "TWN", "Taiwan, Province of China" },
                    { "cc857da7-5f46-40d7-a3d2-5a0d5f8ae681", "TW", "TWN", "Taiwan" },
                    { "249ce334-dcd5-44af-a83b-9113f5727a09", "TJ", "TJK", "Tajikistan" },
                    { "85f7d9d9-72a0-49eb-9209-0fba3cfbabc3", "GS", "SGS", "South Georgia and the South Sandwich Islands" },
                    { "4fa476dd-5ec0-4169-9f74-a9bc1daf6f49", "ZW", "ZWE", "Zimbabwe" },
                    { "ecd2807b-21b8-48ea-990a-0545740e50d7", "LY", "LBY", "Libya" },
                    { "eebde06a-be06-4c55-bdaf-c1f3256456d4", "LS", "LSO", "Lesotho" },
                    { "b7722feb-7b7f-4551-9a22-c204ae4507f8", "BN", "BRN", "Brunei Darussalam" },
                    { "e4bcefdc-b81d-42fa-a948-f0461ce200e3", "BG", "BGR", "Bulgaria" },
                    { "ae2ba562-091a-49bf-b7fc-9163ba1cb456", "BF", "BFA", "Burkina Faso" },
                    { "588d61d1-762a-4d5b-9e4f-3808d821cfff", "BI", "BDI", "Burundi" },
                    { "0d72ef57-3280-4964-9110-bcdd453c21c4", "CV", "CPV", "Cabo Verde" },
                    { "48badab7-dea1-494a-b18e-e79a3dbc7f29", "KH", "KHM", "Cambodia" },
                    { "aa4ddd39-b13f-4ad5-ae1b-dc3400a7eb5f", "CM", "CMR", "Cameroon" },
                    { "876815c3-5a3b-4218-98a5-0578eb4f69c9", "CA", "CAN", "Canada" },
                    { "c28fb193-4250-4adc-a2da-0e6c12836482", "KY", "CYM", "Cayman Islands" },
                    { "1852a666-c2e0-49c4-87a7-f32054e929ee", "CF", "CAF", "Central African Republic" },
                    { "ef8a34f8-cbd0-4a53-acc1-69b41fd25b81", "TD", "TCD", "Chad" },
                    { "fff7597d-cba5-4c7d-9e8f-461b81a44e05", "CL", "CHL", "Chile" },
                    { "b958c3e6-f270-43f3-a3e3-9b540fbeb14c", "CN", "CHN", "China" },
                    { "3a66afa0-cefa-4902-bdd5-1ce64488f754", "CX", "CXR", "Christmas Island" },
                    { "b52fb38f-f387-45ff-be26-2d874b798ed1", "CC", "CCK", "Cocos (Keeling) Islands" },
                    { "90bedfdf-7760-42e3-b74a-36bae7311810", "CO", "COL", "Colombia" },
                    { "591db77c-303d-4b91-bf20-4fdb71eaeb5b", "KM", "COM", "Comoros" },
                    { "a7e7c7cb-6476-42de-8f64-902c6b9b3ade", "CG", "COG", "Congo" },
                    { "3a258673-4522-4ce3-a015-a7488c4f9914", "CD", "COD", "Congo (Democratic Republic of the)" },
                    { "5996e482-56c9-40cd-a2b9-a16ff2b054c5", "CK", "COK", "Cook Islands" },
                    { "8826c780-657c-4f3d-a884-cc1738ea71f1", "CR", "CRI", "Costa Rica" },
                    { "c013b669-802d-453b-80b9-0b158fbb8a21", "CI", "CIV", "Côte d'Ivoire" },
                    { "feefbafb-9029-4244-a388-4dd51f69f517", "HR", "HRV", "Croatia" },
                    { "d5f8be31-b73e-4db1-a2e1-e645a14612c5", "CU", "CUB", "Cuba" },
                    { "6cc28639-c3ed-4e95-8149-06b4cf4ed61b", "CW", "CUW", "Curaçao" },
                    { "57fc8305-67c9-4b75-aca3-1cb40bb6a5e1", "CY", "CYP", "Cyprus" },
                    { "de939231-ee20-4a01-87b2-a9bc0169497c", "CZ", "CZE", "Czechia" },
                    { "9ec999b6-9104-41c4-a3ed-707b54f3e60f", "CZ", "CZE", "Czech Republic" },
                    { "f13dba85-167c-4757-9794-096c5014d032", "DK", "DNK", "Denmark" },
                    { "31ea47ad-8119-464f-976e-03dccc01f7f5", "IO", "IOT", "British Indian Ocean Territory" },
                    { "43c02c42-2421-4f86-8295-f7f57f5b9a6d", "BR", "BRA", "Brazil" },
                    { "c1cb7af8-e166-4275-bb90-92cfbdacd716", "BV", "BVT", "Bouvet Island" },
                    { "c1d6ea0c-340b-47ec-b88a-12818d969ac3", "BW", "BWA", "Botswana" },
                    { "44b36fff-1d8a-42e8-aa06-5300db6f73a3", "AF", "AFG", "Afghanistan" },
                    { "21fcca7d-044e-43f1-a71f-f44a39b6db6d", "AX", "ALA", "Åland Islands" },
                    { "597ad1ff-4805-42f7-bfdf-d3fc1b6a2ddc", "AL", "ALB", "Albania" },
                    { "5ba0f206-408c-49a6-af79-b5bb4ba310ef", "DZ", "DZA", "Algeria" },
                    { "5603b08a-579d-42fa-850c-f9e21435e2ec", "AS", "ASM", "American Samoa" },
                    { "6351dd0a-aeee-4368-868c-8ae9c183a347", "AD", "AND", "Andorra" },
                    { "53cb6e19-29a2-423c-a4a4-cb27f3a1ddd2", "AO", "AGO", "Angola" },
                    { "9d3a5b4e-9cf2-45f9-9b00-7b3ee7648da3", "AI", "AIA", "Anguilla" },
                    { "bc75ad02-314f-40cf-ba35-9df2e17d9a60", "AQ", "ATA", "Antarctica" },
                    { "69b4f6df-6ac9-49bb-9814-161f280d2397", "AG", "ATG", "Antigua and Barbuda" },
                    { "70ead369-9f79-4f46-b621-9283621abd2b", "AR", "ARG", "Argentina" },
                    { "52add52d-ba30-41fa-bd7f-86c4a5147448", "AM", "ARM", "Armenia" },
                    { "5b2fa68a-af76-44f2-bf1c-1adbd8df3d30", "AW", "ABW", "Aruba" },
                    { "e7845cde-5cd4-443d-bbc6-04248f406314", "AU", "AUS", "Australia" },
                    { "8364a2c7-c33d-42ba-a431-e510c5458ed3", "DJ", "DJI", "Djibouti" },
                    { "73100317-77ca-4289-a346-d55d6726a772", "AT", "AUT", "Austria" },
                    { "9f067454-e5eb-4721-96d0-9ab833414b5c", "BS", "BHS", "Bahamas" },
                    { "cd062feb-6656-4cf2-a3bc-1214db15f8ca", "BH", "BHR", "Bahrain" },
                    { "d7bfe1d8-2b4a-4d29-9ae7-a7faa9ab955c", "BD", "BGD", "Bangladesh" },
                    { "5ffad66c-c7dc-405e-84f0-be9ea29204b9", "BB", "BRB", "Barbados" },
                    { "7d33ab08-1cf9-44b4-bb70-af4f193c6fa5", "BY", "BLR", "Belarus" },
                    { "11bb4d8b-83ff-41f7-9279-a5c6d812c650", "BE", "BEL", "Belgium" },
                    { "8d7e00ec-df66-4086-8113-f4b871a172c7", "BZ", "BLZ", "Belize" },
                    { "55de473c-33f9-4e66-ba3a-39d29269b2db", "BJ", "BEN", "Benin" },
                    { "71d33801-de67-4dcb-b837-00a4021fb080", "BM", "BMU", "Bermuda" },
                    { "98219aae-943d-4ed8-8150-336f8b520866", "BT", "BTN", "Bhutan" },
                    { "584acf24-730c-4671-98da-8bdfa8eb1759", "BO", "BOL", "Bolivia (Plurinational State of)" },
                    { "caf7951b-4399-4188-8948-0cd6331c57fa", "BQ", "BES", "Bonaire, Sint Eustatius and Saba" },
                    { "5cf2d0fc-7682-4566-b7f8-cd6203af6b38", "BA", "BIH", "Bosnia and Herzegovina" },
                    { "4d6baf58-5226-4750-9e62-c834efc8a704", "BA", "BIH", "Bosnia & Herzegowina" },
                    { "3de04735-d5b2-48ba-9440-e14b8682ce65", "AZ", "AZE", "Azerbaijan" },
                    { "eeff84da-34b4-4509-b842-fb49031d7c91", "LR", "LBR", "Liberia" },
                    { "70c0dbf1-12a9-499e-aef5-ef3c92ad8e37", "DM", "DMA", "Dominica" },
                    { "9b0bc9c1-bc01-4ee5-b46c-c1689076ec24", "EC", "ECU", "Ecuador" },
                    { "e767804c-cb3f-4502-bc0f-b732208014ff", "HN", "HND", "Honduras" },
                    { "b8818db5-8922-4f7a-82d9-0141ad4a45a5", "HK", "HKG", "Hong Kong" },
                    { "4725a19c-3abe-4609-b65a-01a9c47f2d89", "HU", "HUN", "Hungary" },
                    { "25efcfa1-b91a-4bcb-b153-406651565651", "IS", "ISL", "Iceland" },
                    { "54031f93-dfeb-43fe-b2d5-27b16e105d7b", "IN", "IND", "India" },
                    { "e7039d66-7d6c-4f42-b5f1-6a79287c098d", "ID", "IDN", "Indonesia" },
                    { "e696352f-5a53-4b81-9109-0fab91ea1956", "IR", "IRN", "Iran (Islamic Republic of)" },
                    { "68c633b0-a50e-4b26-b787-addf353fa502", "IR", "IRN", "Iran" },
                    { "b320d017-bb3b-48c4-8871-fe2cf1d6f8ac", "IQ", "IRQ", "Iraq" },
                    { "1c91fb93-cbc0-4194-9a52-5fa839853034", "IE", "IRL", "Ireland" },
                    { "0d9ab580-6175-468c-8318-9101445cd543", "IM", "IMN", "Isle of Man" },
                    { "d738d352-9e4e-4222-b252-0eb3634e0228", "IL", "ISR", "Israel" },
                    { "e9e9e670-a51b-4743-a0f3-bed2451b564c", "IT", "ITA", "Italy" },
                    { "05abe794-8f0c-43ae-8305-9ac04d3a0830", "JM", "JAM", "Jamaica" },
                    { "b7de5e6b-a00e-453a-992e-5d95680a0179", "JP", "JPN", "Japan" },
                    { "8687d0b7-0890-4ab6-a57e-8361220707ee", "JE", "JEY", "Jersey" },
                    { "5f1a49be-f5da-42d7-b728-5e9fd068ec1a", "JO", "JOR", "Jordan" },
                    { "0411bfb0-4b68-461a-a4d7-7f3997242a3c", "KZ", "KAZ", "Kazakhstan" },
                    { "5dcee40a-98b3-46fe-9e94-4aeac8c9cb2f", "KE", "KEN", "Kenya" },
                    { "27f97629-1fa5-4fcd-8c58-8719f25080cb", "KI", "KIR", "Kiribati" },
                    { "1095ec61-6139-47ed-8d89-a814df34417d", "KP", "PRK", "Korea (Democratic People's Republic of)" },
                    { "2f59b79e-ebcc-4a19-9641-e020ebaee3cd", "KR", "KOR", "Korea (Republic of)" },
                    { "8822f89f-9246-4289-a96a-d8a176f6cf74", "KR", "KOR", "Korea" },
                    { "13fbff1b-6c8d-41ee-9a21-15a24a9ab733", "KW", "KWT", "Kuwait" },
                    { "623ffb3b-4182-4462-9665-9e798960c885", "KG", "KGZ", "Kyrgyzstan" },
                    { "d95a00c5-a2bd-4d1f-bce7-5f28a2261305", "LA", "LAO", "Lao People's Democratic Republic" },
                    { "ee9fbb8c-76ce-4a0b-93cd-83eeafe15178", "LA", "LAO", "Laos" },
                    { "c39d6350-8857-433a-8c11-6c474c09ad7f", "LV", "LVA", "Latvia" },
                    { "ab502518-caa8-4416-92f6-c22002ba19a0", "LB", "LBN", "Lebanon" },
                    { "6aa16a10-71ad-4bf6-a4d0-80095a9d92b2", "VA", "VAT", "Holy See" },
                    { "4e4c0446-5fc0-4811-8536-9b3f23344616", "HM", "HMD", "Heard Island and McDonald Islands" },
                    { "5de8d9d5-1be5-4d14-b391-8dfedfb4f23f", "HT", "HTI", "Haiti" },
                    { "0c82439e-e73f-43c9-8651-01f4f30a2521", "GY", "GUY", "Guyana" },
                    { "7ad18a2a-30a5-4407-9308-7e88adb706d9", "EG", "EGY", "Egypt" },
                    { "c80f3585-19e3-427c-abf4-042acdd257a3", "SV", "SLV", "El Salvador" },
                    { "52889d45-fd3e-4154-a44f-cc483bf822ab", "GQ", "GNQ", "Equatorial Guinea" },
                    { "3d4bde3f-9d6f-4882-9398-4e5df284dd19", "ER", "ERI", "Eritrea" },
                    { "e9043d37-7aca-4d97-abd4-439afe4ff536", "EE", "EST", "Estonia" },
                    { "75cf2f58-8b9a-4553-8f68-3a7f2df45ee8", "SZ", "SWZ", "Eswatini" },
                    { "72add91d-b063-4706-a1f5-d999ff751504", "ET", "ETH", "Ethiopia" },
                    { "9f550658-c521-474d-9aae-65c12effc11f", "FK", "FLK", "Falkland Islands (Malvinas)" },
                    { "e9a63c1a-6d15-435e-8705-3cfaeb443571", "FO", "FRO", "Faroe Islands" },
                    { "c54d79f7-b117-45a1-a09e-066542bf9e3d", "FJ", "FJI", "Fiji" },
                    { "8057be7d-9e49-4721-9872-b3274dab1a50", "FI", "FIN", "Finland" },
                    { "c87f2f17-8557-48ee-ac18-f94e0ea13c81", "FR", "FRA", "France" },
                    { "835f5ef4-c339-471d-bac1-694af0323a9b", "GF", "GUF", "French Guiana" },
                    { "c07e0f0c-158f-4ba6-b953-f9b7faa31516", "PF", "PYF", "French Polynesia" },
                    { "faaf6f33-d8cd-4c4f-b0a5-19860a6f1290", "DO", "DOM", "Dominican Republic" },
                    { "e14e9227-0f97-473f-8008-095572d8de4c", "TF", "ATF", "French Southern Territories" },
                    { "b7c25e29-2a59-4882-8a36-9aed9fe4de1c", "GM", "GMB", "Gambia" },
                    { "a1460ffe-64ad-408e-9b37-990f0d36c697", "GE", "GEO", "Georgia" },
                    { "b8ca640b-0a6b-4c29-bd4a-9a8c76d4ccb2", "DE", "DEU", "Germany" },
                    { "4d22d98a-fcc1-4b4a-aa57-749ea8decf0d", "GH", "GHA", "Ghana" },
                    { "25df0670-d028-426c-994e-a5db33614fac", "GI", "GIB", "Gibraltar" },
                    { "9f79f61b-3821-42a5-88fc-687a52fca613", "GR", "GRC", "Greece" },
                    { "4bddbebc-5097-4d2a-9cd7-c2d654d6e7f2", "GL", "GRL", "Greenland" },
                    { "4520c6a8-c0fd-45f5-90a6-4fc78c6f0951", "GD", "GRD", "Grenada" },
                    { "c731f2b6-d69e-4c4a-839d-dc4db2a80369", "GP", "GLP", "Guadeloupe" },
                    { "3230ff87-4f7d-41e1-8be1-bb2d33d3b9a5", "GU", "GUM", "Guam" },
                    { "ffbcc443-d529-4427-ae47-024c6fd6ece8", "GT", "GTM", "Guatemala" },
                    { "d4f95491-d7c2-4919-8d19-f87e22dca34f", "GG", "GGY", "Guernsey" },
                    { "9aa0c3eb-97ab-46c2-8909-9b6d7a3b34e5", "GN", "GIN", "Guinea" },
                    { "1e8bd3f1-a52d-4d75-bb58-a2146255a792", "GW", "GNB", "Guinea-Bissau" },
                    { "6650ed21-db40-4554-a965-28f2e34ed808", "GA", "GAB", "Gabon" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name" },
                values: new object[] { "6401cf99-a0dc-4747-9232-d307b21a360c", "superadmin" });

            migrationBuilder.InsertData(
                table: "Area",
                columns: new[] { "Id", "Accomodations", "Approach", "ApprovedById", "ApprovedOn", "ConcurrencyToken", "CountryId", "CreatedById", "CreatedOn", "Descent", "Ethics", "History", "Info", "Name", "ParentId", "Restrictions", "Revision", "Status", "UpdatedById", "UpdatedOn" },
                values: new object[] { "20144484-65bf-4c55-9f53-3e41cee9d923", null, null, null, null, null, "67ef12fb-6c70-4763-bfc6-34575cfd6012", "6401cf99-a0dc-4747-9232-d307b21a360c", new DateTime(2019, 11, 30, 20, 55, 59, 232, DateTimeKind.Local).AddTicks(1023), null, null, null, "Prilep info.", "Prilep", null, null, 1, 2, null, null });

            migrationBuilder.InsertData(
                table: "Area",
                columns: new[] { "Id", "Accomodations", "Approach", "ApprovedById", "ApprovedOn", "ConcurrencyToken", "CountryId", "CreatedById", "CreatedOn", "Descent", "Ethics", "History", "Info", "Name", "ParentId", "Restrictions", "Revision", "Status", "UpdatedById", "UpdatedOn" },
                values: new object[] { "c2fccbf6-4363-4850-ad97-54954812457e", null, null, null, null, null, "67ef12fb-6c70-4763-bfc6-34575cfd6012", "6401cf99-a0dc-4747-9232-d307b21a360c", new DateTime(2019, 11, 30, 20, 55, 59, 235, DateTimeKind.Local).AddTicks(5657), null, null, null, "Treskavets Area info.", "Treskavets", "20144484-65bf-4c55-9f53-3e41cee9d923", null, 1, 2, null, null });

            migrationBuilder.InsertData(
                table: "Area",
                columns: new[] { "Id", "Accomodations", "Approach", "ApprovedById", "ApprovedOn", "ConcurrencyToken", "CountryId", "CreatedById", "CreatedOn", "Descent", "Ethics", "History", "Info", "Name", "ParentId", "Restrictions", "Revision", "Status", "UpdatedById", "UpdatedOn" },
                values: new object[] { "64875f09-3072-4dab-9d9f-d7286ce818a9", null, null, null, null, null, "67ef12fb-6c70-4763-bfc6-34575cfd6012", "6401cf99-a0dc-4747-9232-d307b21a360c", new DateTime(2019, 11, 30, 20, 55, 59, 235, DateTimeKind.Local).AddTicks(5797), null, null, null, "Kamena baba info.", "Kamena baba", "20144484-65bf-4c55-9f53-3e41cee9d923", null, 1, 2, null, null });

            migrationBuilder.InsertData(
                table: "Area",
                columns: new[] { "Id", "Accomodations", "Approach", "ApprovedById", "ApprovedOn", "ConcurrencyToken", "CountryId", "CreatedById", "CreatedOn", "Descent", "Ethics", "History", "Info", "Name", "ParentId", "Restrictions", "Revision", "Status", "UpdatedById", "UpdatedOn" },
                values: new object[] { "8d7d8b36-489b-4d9a-bd73-a7caa9853356", null, null, null, null, null, "67ef12fb-6c70-4763-bfc6-34575cfd6012", "6401cf99-a0dc-4747-9232-d307b21a360c", new DateTime(2019, 11, 30, 20, 55, 59, 235, DateTimeKind.Local).AddTicks(5763), null, null, null, "Paragliding info.", "Paragliding", "c2fccbf6-4363-4850-ad97-54954812457e", null, 1, 2, null, null });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "Id", "Approach", "ApprovedById", "ApprovedOn", "AreaId", "ConcurrencyToken", "CreatedById", "CreatedOn", "Difficulty", "History", "Info", "Length", "Name", "Rating", "Revision", "RouteId", "Status", "Type", "UpdatedById", "UpdatedOn" },
                values: new object[] { "9dd6e524-6152-4cd0-8f81-7db94779b274", null, null, null, "8d7d8b36-489b-4d9a-bd73-a7caa9853356", null, "6401cf99-a0dc-4747-9232-d307b21a360c", new DateTime(2019, 11, 30, 20, 55, 59, 236, DateTimeKind.Local).AddTicks(940), 105.0, null, "Shitstorm info.", 4, "Shitstorm", 4f, 1, null, 2, 1, null, null });

            migrationBuilder.InsertData(
                table: "SchemaPoint",
                columns: new[] { "RouteId", "Id", "X", "Y" },
                values: new object[,]
                {
                    { "9dd6e524-6152-4cd0-8f81-7db94779b274", 1, 0.5, 0.80000000000000004 },
                    { "9dd6e524-6152-4cd0-8f81-7db94779b274", 2, 0.29999999999999999, 0.55000000000000004 },
                    { "9dd6e524-6152-4cd0-8f81-7db94779b274", 3, 0.84999999999999998, 0.45000000000000001 },
                    { "9dd6e524-6152-4cd0-8f81-7db94779b274", 4, 0.5, 0.10000000000000001 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Area_ApprovedById",
                table: "Area",
                column: "ApprovedById");

            migrationBuilder.CreateIndex(
                name: "IX_Area_CountryId",
                table: "Area",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Area_CreatedById",
                table: "Area",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Area_ParentId",
                table: "Area",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Area_UpdatedById",
                table: "Area",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_ApprovedById",
                table: "Routes",
                column: "ApprovedById");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_AreaId",
                table: "Routes",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_CreatedById",
                table: "Routes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_RouteId",
                table: "Routes",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_UpdatedById",
                table: "Routes",
                column: "UpdatedById");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SchemaPoint");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
