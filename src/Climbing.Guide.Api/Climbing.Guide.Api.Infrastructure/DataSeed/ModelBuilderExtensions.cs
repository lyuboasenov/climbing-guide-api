using Climbing.Guide.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Climbing.Guide.Api.Infrastructure.DataSeed {
   public static class ModelBuilderExtensions {
      public static void EnsureSeedData(this ModelBuilder builder) {
         builder.EnsureUsersExist();
         builder.EnsureCountriesExist();
         builder.EnsureAreasExist();
      }

      private static void EnsureAreasExist(this ModelBuilder builder) {
         string nullStr = null;
         builder.Entity<AreasContainer>().HasData(
            new {
               Id = "20144484-65bf-4c55-9f53-3e41cee9d923",
               ParentId = nullStr,
               Name = "Prilep",
               Info = "Prilep info.",
               CountryId = "dfa4af2c-d01d-4a8a-825e-793d49a656ac",
               CreatedById = "6401cf99-a0dc-4747-9232-d307b21a360c",
               CreatedOn = DateTime.Now,
               Revision = 1,
               Status = EntityStatus.Active,
               Location_Latitude = 41.345351,
               Location_Longitude = 21.552799
            });

         builder.Entity<AreasContainer>().HasData(
            new {
               Id = "c2fccbf6-4363-4850-ad97-54954812457e",
               ParentId = "20144484-65bf-4c55-9f53-3e41cee9d923",
               AreaContainerId = "20144484-65bf-4c55-9f53-3e41cee9d923",
               Name = "Treskavets",
               Info = "Treskavets Area info.",
               CountryId = "dfa4af2c-d01d-4a8a-825e-793d49a656ac",
               CreatedById = "6401cf99-a0dc-4747-9232-d307b21a360c",
               CreatedOn = DateTime.Now,
               Revision = 1,
               Status = EntityStatus.Active,
               Location_Latitude = 41.403831,
               Location_Longitude = 21.538183
            });

         builder.Entity<RoutesContainer>().HasData(
            new {
               Id = "8d7d8b36-489b-4d9a-bd73-a7caa9853356",
               ParentId = "c2fccbf6-4363-4850-ad97-54954812457e",
               Name = "Paragliding",
               Info = "Paragliding info.",
               CountryId = "dfa4af2c-d01d-4a8a-825e-793d49a656ac",
               CreatedById = "6401cf99-a0dc-4747-9232-d307b21a360c",
               CreatedOn = DateTime.Now,
               Revision = 1,
               Status = EntityStatus.Active,
               Location_Latitude = 41.397296,
               Location_Longitude = 21.532008
            });

         builder.Entity<AreasContainer>().HasData(
            new {
               Id = "64875f09-3072-4dab-9d9f-d7286ce818a9",
               ParentId = "20144484-65bf-4c55-9f53-3e41cee9d923",
               AreaContainerId = "20144484-65bf-4c55-9f53-3e41cee9d923",
               Name = "Kamena baba",
               Info = "Kamena baba info.",
               CountryId = "dfa4af2c-d01d-4a8a-825e-793d49a656ac",
               CreatedById = "6401cf99-a0dc-4747-9232-d307b21a360c",
               CreatedOn = DateTime.Now,
               Revision = 1,
               Status = EntityStatus.Active,
               Location_Latitude = 41.3816981439556,
               Location_Longitude = 21.5779556147754
            });
      }

      private static void EnsureUsersExist(this ModelBuilder builder) {
         builder.Entity<User>().HasData(new User() {
            Id = "6401cf99-a0dc-4747-9232-d307b21a360c",
            Name = "superadmin"
         });
      }

      private static void EnsureCountriesExist(this ModelBuilder builder) {
         builder.Entity<Country>().HasData(new {
            Id = "9235cd70-220e-47d9-b76e-17a81d1db7f5",
            Name = "Afghanistan",
            Code2 = "AF",
            Code3 = "AFG",
            Location_Latitude = 33.93911,
            Location_Longitude = 67.709953
         });

         builder.Entity<Country>().HasData(new {
            Id = "44b36fff-1d8a-42e8-aa06-5300db6f73a3",
            Name = "Afghanistan",
            Code2 = "AF",
            Code3 = "AFG",
            Location_Latitude = 33.93911,
            Location_Longitude = 67.709953
         });

         builder.Entity<Country>().HasData(new {
            Id = "21fcca7d-044e-43f1-a71f-f44a39b6db6d",
            Name = "Åland Islands",
            Code2 = "AX",
            Code3 = "ALA",
            Location_Latitude = 0,
            Location_Longitude = 0
         });

         builder.Entity<Country>().HasData(new {
            Id = "597ad1ff-4805-42f7-bfdf-d3fc1b6a2ddc",
            Name = "Albania",
            Code2 = "AL",
            Code3 = "ALB",
            Location_Latitude = 41.153332,
            Location_Longitude = 20.168331
         });

         builder.Entity<Country>().HasData(new {
            Id = "5ba0f206-408c-49a6-af79-b5bb4ba310ef",
            Name = "Algeria",
            Code2 = "DZ",
            Code3 = "DZA",
            Location_Latitude = 28.033886,
            Location_Longitude = 1.659626
         });

         builder.Entity<Country>().HasData(new {
            Id = "5603b08a-579d-42fa-850c-f9e21435e2ec",
            Name = "American Samoa",
            Code2 = "AS",
            Code3 = "ASM",
            Location_Latitude = -14.270972,
            Location_Longitude = -170.132217
         });

         builder.Entity<Country>().HasData(new {
            Id = "6351dd0a-aeee-4368-868c-8ae9c183a347",
            Name = "Andorra",
            Code2 = "AD",
            Code3 = "AND",
            Location_Latitude = 42.546245,
            Location_Longitude = 1.601554
         });

         builder.Entity<Country>().HasData(new {
            Id = "53cb6e19-29a2-423c-a4a4-cb27f3a1ddd2",
            Name = "Angola",
            Code2 = "AO",
            Code3 = "AGO",
            Location_Latitude = -11.202692,
            Location_Longitude = 17.873887
         });

         builder.Entity<Country>().HasData(new {
            Id = "9d3a5b4e-9cf2-45f9-9b00-7b3ee7648da3",
            Name = "Anguilla",
            Code2 = "AI",
            Code3 = "AIA",
            Location_Latitude = 18.220554,
            Location_Longitude = -63.068615
         });

         builder.Entity<Country>().HasData(new {
            Id = "bc75ad02-314f-40cf-ba35-9df2e17d9a60",
            Name = "Antarctica",
            Code2 = "AQ",
            Code3 = "ATA",
            Location_Latitude = -75.250973,
            Location_Longitude = -0.071389
         });

         builder.Entity<Country>().HasData(new {
            Id = "69b4f6df-6ac9-49bb-9814-161f280d2397",
            Name = "Antigua and Barbuda",
            Code2 = "AG",
            Code3 = "ATG",
            Location_Latitude = 17.060816,
            Location_Longitude = -61.796428
         });

         builder.Entity<Country>().HasData(new {
            Id = "70ead369-9f79-4f46-b621-9283621abd2b",
            Name = "Argentina",
            Code2 = "AR",
            Code3 = "ARG",
            Location_Latitude = -38.416097,
            Location_Longitude = -63.616672
         });

         builder.Entity<Country>().HasData(new {
            Id = "52add52d-ba30-41fa-bd7f-86c4a5147448",
            Name = "Armenia",
            Code2 = "AM",
            Code3 = "ARM",
            Location_Latitude = 40.069099,
            Location_Longitude = 45.038189
         });

         builder.Entity<Country>().HasData(new {
            Id = "5b2fa68a-af76-44f2-bf1c-1adbd8df3d30",
            Name = "Aruba",
            Code2 = "AW",
            Code3 = "ABW",
            Location_Latitude = 12.52111,
            Location_Longitude = -69.968338
         });

         builder.Entity<Country>().HasData(new {
            Id = "e7845cde-5cd4-443d-bbc6-04248f406314",
            Name = "Australia",
            Code2 = "AU",
            Code3 = "AUS",
            Location_Latitude = -25.274398,
            Location_Longitude = 133.775136
         });

         builder.Entity<Country>().HasData(new {
            Id = "73100317-77ca-4289-a346-d55d6726a772",
            Name = "Austria",
            Code2 = "AT",
            Code3 = "AUT",
            Location_Latitude = 47.516231,
            Location_Longitude = 14.550072
         });

         builder.Entity<Country>().HasData(new {
            Id = "3de04735-d5b2-48ba-9440-e14b8682ce65",
            Name = "Azerbaijan",
            Code2 = "AZ",
            Code3 = "AZE",
            Location_Latitude = 40.143105,
            Location_Longitude = 47.576927
         });

         builder.Entity<Country>().HasData(new {
            Id = "9f067454-e5eb-4721-96d0-9ab833414b5c",
            Name = "Bahamas",
            Code2 = "BS",
            Code3 = "BHS",
            Location_Latitude = 25.03428,
            Location_Longitude = -77.39628
         });

         builder.Entity<Country>().HasData(new {
            Id = "cd062feb-6656-4cf2-a3bc-1214db15f8ca",
            Name = "Bahrain",
            Code2 = "BH",
            Code3 = "BHR",
            Location_Latitude = 25.930414,
            Location_Longitude = 50.637772
         });

         builder.Entity<Country>().HasData(new {
            Id = "d7bfe1d8-2b4a-4d29-9ae7-a7faa9ab955c",
            Name = "Bangladesh",
            Code2 = "BD",
            Code3 = "BGD",
            Location_Latitude = 23.684994,
            Location_Longitude = 90.356331
         });

         builder.Entity<Country>().HasData(new {
            Id = "5ffad66c-c7dc-405e-84f0-be9ea29204b9",
            Name = "Barbados",
            Code2 = "BB",
            Code3 = "BRB",
            Location_Latitude = 13.193887,
            Location_Longitude = -59.543198
         });

         builder.Entity<Country>().HasData(new {
            Id = "7d33ab08-1cf9-44b4-bb70-af4f193c6fa5",
            Name = "Belarus",
            Code2 = "BY",
            Code3 = "BLR",
            Location_Latitude = 53.709807,
            Location_Longitude = 27.953389
         });

         builder.Entity<Country>().HasData(new {
            Id = "11bb4d8b-83ff-41f7-9279-a5c6d812c650",
            Name = "Belgium",
            Code2 = "BE",
            Code3 = "BEL",
            Location_Latitude = 50.503887,
            Location_Longitude = 4.469936
         });

         builder.Entity<Country>().HasData(new {
            Id = "8d7e00ec-df66-4086-8113-f4b871a172c7",
            Name = "Belize",
            Code2 = "BZ",
            Code3 = "BLZ",
            Location_Latitude = 17.189877,
            Location_Longitude = -88.49765
         });

         builder.Entity<Country>().HasData(new {
            Id = "55de473c-33f9-4e66-ba3a-39d29269b2db",
            Name = "Benin",
            Code2 = "BJ",
            Code3 = "BEN",
            Location_Latitude = 9.30769,
            Location_Longitude = 2.315834
         });

         builder.Entity<Country>().HasData(new {
            Id = "71d33801-de67-4dcb-b837-00a4021fb080",
            Name = "Bermuda",
            Code2 = "BM",
            Code3 = "BMU",
            Location_Latitude = 32.321384,
            Location_Longitude = -64.75737
         });

         builder.Entity<Country>().HasData(new {
            Id = "98219aae-943d-4ed8-8150-336f8b520866",
            Name = "Bhutan",
            Code2 = "BT",
            Code3 = "BTN",
            Location_Latitude = 27.514162,
            Location_Longitude = 90.433601
         });

         builder.Entity<Country>().HasData(new {
            Id = "584acf24-730c-4671-98da-8bdfa8eb1759",
            Name = "Bolivia (Plurinational State of)",
            Code2 = "BO",
            Code3 = "BOL",
            Location_Latitude = -16.290154,
            Location_Longitude = -63.588653
         });

         builder.Entity<Country>().HasData(new {
            Id = "caf7951b-4399-4188-8948-0cd6331c57fa",
            Name = "Bonaire, Sint Eustatius and Saba",
            Code2 = "BQ",
            Code3 = "BES",
            Location_Latitude = 0,
            Location_Longitude = 0
         });

         builder.Entity<Country>().HasData(new {
            Id = "5cf2d0fc-7682-4566-b7f8-cd6203af6b38",
            Name = "Bosnia and Herzegovina",
            Code2 = "BA",
            Code3 = "BIH",
            Location_Latitude = 43.915886,
            Location_Longitude = 17.679076
         });

         builder.Entity<Country>().HasData(new {
            Id = "4d6baf58-5226-4750-9e62-c834efc8a704",
            Name = "Bosnia & Herzegowina",
            Code2 = "BA",
            Code3 = "BIH",
            Location_Latitude = 43.915886,
            Location_Longitude = 17.679076
         });

         builder.Entity<Country>().HasData(new {
            Id = "c1d6ea0c-340b-47ec-b88a-12818d969ac3",
            Name = "Botswana",
            Code2 = "BW",
            Code3 = "BWA",
            Location_Latitude = -22.328474,
            Location_Longitude = 24.684866
         });

         builder.Entity<Country>().HasData(new {
            Id = "c1cb7af8-e166-4275-bb90-92cfbdacd716",
            Name = "Bouvet Island",
            Code2 = "BV",
            Code3 = "BVT",
            Location_Latitude = -54.423199,
            Location_Longitude = 3.413194
         });

         builder.Entity<Country>().HasData(new {
            Id = "43c02c42-2421-4f86-8295-f7f57f5b9a6d",
            Name = "Brazil",
            Code2 = "BR",
            Code3 = "BRA",
            Location_Latitude = -14.235004,
            Location_Longitude = -51.92528
         });

         builder.Entity<Country>().HasData(new {
            Id = "31ea47ad-8119-464f-976e-03dccc01f7f5",
            Name = "British Indian Ocean Territory",
            Code2 = "IO",
            Code3 = "IOT",
            Location_Latitude = -6.343194,
            Location_Longitude = 71.876519
         });

         builder.Entity<Country>().HasData(new {
            Id = "b7722feb-7b7f-4551-9a22-c204ae4507f8",
            Name = "Brunei Darussalam",
            Code2 = "BN",
            Code3 = "BRN",
            Location_Latitude = 4.535277,
            Location_Longitude = 114.727669
         });

         builder.Entity<Country>().HasData(new {
            Id = "e4bcefdc-b81d-42fa-a948-f0461ce200e3",
            Name = "Bulgaria",
            Code2 = "BG",
            Code3 = "BGR",
            Location_Latitude = 42.733883,
            Location_Longitude = 25.48583
         });

         builder.Entity<Country>().HasData(new {
            Id = "ae2ba562-091a-49bf-b7fc-9163ba1cb456",
            Name = "Burkina Faso",
            Code2 = "BF",
            Code3 = "BFA",
            Location_Latitude = 12.238333,
            Location_Longitude = -1.561593
         });

         builder.Entity<Country>().HasData(new {
            Id = "588d61d1-762a-4d5b-9e4f-3808d821cfff",
            Name = "Burundi",
            Code2 = "BI",
            Code3 = "BDI",
            Location_Latitude = -3.373056,
            Location_Longitude = 29.918886
         });

         builder.Entity<Country>().HasData(new {
            Id = "0d72ef57-3280-4964-9110-bcdd453c21c4",
            Name = "Cabo Verde",
            Code2 = "CV",
            Code3 = "CPV",
            Location_Latitude = 16.002082,
            Location_Longitude = -24.013197
         });

         builder.Entity<Country>().HasData(new {
            Id = "48badab7-dea1-494a-b18e-e79a3dbc7f29",
            Name = "Cambodia",
            Code2 = "KH",
            Code3 = "KHM",
            Location_Latitude = 12.565679,
            Location_Longitude = 104.990963
         });

         builder.Entity<Country>().HasData(new {
            Id = "aa4ddd39-b13f-4ad5-ae1b-dc3400a7eb5f",
            Name = "Cameroon",
            Code2 = "CM",
            Code3 = "CMR",
            Location_Latitude = 7.369722,
            Location_Longitude = 12.354722
         });

         builder.Entity<Country>().HasData(new {
            Id = "876815c3-5a3b-4218-98a5-0578eb4f69c9",
            Name = "Canada",
            Code2 = "CA",
            Code3 = "CAN",
            Location_Latitude = 56.130366,
            Location_Longitude = -106.346771
         });

         builder.Entity<Country>().HasData(new {
            Id = "c28fb193-4250-4adc-a2da-0e6c12836482",
            Name = "Cayman Islands",
            Code2 = "KY",
            Code3 = "CYM",
            Location_Latitude = 19.513469,
            Location_Longitude = -80.566956
         });

         builder.Entity<Country>().HasData(new {
            Id = "1852a666-c2e0-49c4-87a7-f32054e929ee",
            Name = "Central African Republic",
            Code2 = "CF",
            Code3 = "CAF",
            Location_Latitude = 6.611111,
            Location_Longitude = 20.939444
         });

         builder.Entity<Country>().HasData(new {
            Id = "ef8a34f8-cbd0-4a53-acc1-69b41fd25b81",
            Name = "Chad",
            Code2 = "TD",
            Code3 = "TCD",
            Location_Latitude = 15.454166,
            Location_Longitude = 18.732207
         });

         builder.Entity<Country>().HasData(new {
            Id = "fff7597d-cba5-4c7d-9e8f-461b81a44e05",
            Name = "Chile",
            Code2 = "CL",
            Code3 = "CHL",
            Location_Latitude = -35.675147,
            Location_Longitude = -71.542969
         });

         builder.Entity<Country>().HasData(new {
            Id = "b958c3e6-f270-43f3-a3e3-9b540fbeb14c",
            Name = "China",
            Code2 = "CN",
            Code3 = "CHN",
            Location_Latitude = 35.86166,
            Location_Longitude = 104.195397
         });

         builder.Entity<Country>().HasData(new {
            Id = "3a66afa0-cefa-4902-bdd5-1ce64488f754",
            Name = "Christmas Island",
            Code2 = "CX",
            Code3 = "CXR",
            Location_Latitude = -10.447525,
            Location_Longitude = 105.690449
         });

         builder.Entity<Country>().HasData(new {
            Id = "b52fb38f-f387-45ff-be26-2d874b798ed1",
            Name = "Cocos (Keeling) Islands",
            Code2 = "CC",
            Code3 = "CCK",
            Location_Latitude = -12.164165,
            Location_Longitude = 96.870956
         });

         builder.Entity<Country>().HasData(new {
            Id = "90bedfdf-7760-42e3-b74a-36bae7311810",
            Name = "Colombia",
            Code2 = "CO",
            Code3 = "COL",
            Location_Latitude = 4.570868,
            Location_Longitude = -74.297333
         });

         builder.Entity<Country>().HasData(new {
            Id = "591db77c-303d-4b91-bf20-4fdb71eaeb5b",
            Name = "Comoros",
            Code2 = "KM",
            Code3 = "COM",
            Location_Latitude = -11.875001,
            Location_Longitude = 43.872219
         });

         builder.Entity<Country>().HasData(new {
            Id = "a7e7c7cb-6476-42de-8f64-902c6b9b3ade",
            Name = "Congo",
            Code2 = "CG",
            Code3 = "COG",
            Location_Latitude = -0.228021,
            Location_Longitude = 15.827659
         });

         builder.Entity<Country>().HasData(new {
            Id = "3a258673-4522-4ce3-a015-a7488c4f9914",
            Name = "Congo (Democratic Republic of the)",
            Code2 = "CD",
            Code3 = "COD",
            Location_Latitude = -4.038333,
            Location_Longitude = 21.758664
         });

         builder.Entity<Country>().HasData(new {
            Id = "5996e482-56c9-40cd-a2b9-a16ff2b054c5",
            Name = "Cook Islands",
            Code2 = "CK",
            Code3 = "COK",
            Location_Latitude = -21.236736,
            Location_Longitude = -159.777671
         });

         builder.Entity<Country>().HasData(new {
            Id = "8826c780-657c-4f3d-a884-cc1738ea71f1",
            Name = "Costa Rica",
            Code2 = "CR",
            Code3 = "CRI",
            Location_Latitude = 9.748917,
            Location_Longitude = -83.753428
         });

         builder.Entity<Country>().HasData(new {
            Id = "c013b669-802d-453b-80b9-0b158fbb8a21",
            Name = "Côte d'Ivoire",
            Code2 = "CI",
            Code3 = "CIV",
            Location_Latitude = 7.539989,
            Location_Longitude = -5.54708
         });

         builder.Entity<Country>().HasData(new {
            Id = "feefbafb-9029-4244-a388-4dd51f69f517",
            Name = "Croatia",
            Code2 = "HR",
            Code3 = "HRV",
            Location_Latitude = 45.1,
            Location_Longitude = 15.2
         });

         builder.Entity<Country>().HasData(new {
            Id = "d5f8be31-b73e-4db1-a2e1-e645a14612c5",
            Name = "Cuba",
            Code2 = "CU",
            Code3 = "CUB",
            Location_Latitude = 21.521757,
            Location_Longitude = -77.781167
         });

         builder.Entity<Country>().HasData(new {
            Id = "6cc28639-c3ed-4e95-8149-06b4cf4ed61b",
            Name = "Curaçao",
            Code2 = "CW",
            Code3 = "CUW",
            Location_Latitude = 0,
            Location_Longitude = 0
         });

         builder.Entity<Country>().HasData(new {
            Id = "57fc8305-67c9-4b75-aca3-1cb40bb6a5e1",
            Name = "Cyprus",
            Code2 = "CY",
            Code3 = "CYP",
            Location_Latitude = 35.126413,
            Location_Longitude = 33.429859
         });

         builder.Entity<Country>().HasData(new {
            Id = "de939231-ee20-4a01-87b2-a9bc0169497c",
            Name = "Czechia",
            Code2 = "CZ",
            Code3 = "CZE",
            Location_Latitude = 49.817492,
            Location_Longitude = 15.472962
         });

         builder.Entity<Country>().HasData(new {
            Id = "9ec999b6-9104-41c4-a3ed-707b54f3e60f",
            Name = "Czech Republic",
            Code2 = "CZ",
            Code3 = "CZE",
            Location_Latitude = 49.817492,
            Location_Longitude = 15.472962
         });

         builder.Entity<Country>().HasData(new {
            Id = "f13dba85-167c-4757-9794-096c5014d032",
            Name = "Denmark",
            Code2 = "DK",
            Code3 = "DNK",
            Location_Latitude = 56.26392,
            Location_Longitude = 9.501785
         });

         builder.Entity<Country>().HasData(new {
            Id = "8364a2c7-c33d-42ba-a431-e510c5458ed3",
            Name = "Djibouti",
            Code2 = "DJ",
            Code3 = "DJI",
            Location_Latitude = 11.825138,
            Location_Longitude = 42.590275
         });

         builder.Entity<Country>().HasData(new {
            Id = "70c0dbf1-12a9-499e-aef5-ef3c92ad8e37",
            Name = "Dominica",
            Code2 = "DM",
            Code3 = "DMA",
            Location_Latitude = 15.414999,
            Location_Longitude = -61.370976
         });

         builder.Entity<Country>().HasData(new {
            Id = "faaf6f33-d8cd-4c4f-b0a5-19860a6f1290",
            Name = "Dominican Republic",
            Code2 = "DO",
            Code3 = "DOM",
            Location_Latitude = 18.735693,
            Location_Longitude = -70.162651
         });

         builder.Entity<Country>().HasData(new {
            Id = "9b0bc9c1-bc01-4ee5-b46c-c1689076ec24",
            Name = "Ecuador",
            Code2 = "EC",
            Code3 = "ECU",
            Location_Latitude = -1.831239,
            Location_Longitude = -78.183406
         });

         builder.Entity<Country>().HasData(new {
            Id = "7ad18a2a-30a5-4407-9308-7e88adb706d9",
            Name = "Egypt",
            Code2 = "EG",
            Code3 = "EGY",
            Location_Latitude = 26.820553,
            Location_Longitude = 30.802498
         });

         builder.Entity<Country>().HasData(new {
            Id = "c80f3585-19e3-427c-abf4-042acdd257a3",
            Name = "El Salvador",
            Code2 = "SV",
            Code3 = "SLV",
            Location_Latitude = 13.794185,
            Location_Longitude = -88.89653
         });

         builder.Entity<Country>().HasData(new {
            Id = "52889d45-fd3e-4154-a44f-cc483bf822ab",
            Name = "Equatorial Guinea",
            Code2 = "GQ",
            Code3 = "GNQ",
            Location_Latitude = 1.650801,
            Location_Longitude = 10.267895
         });

         builder.Entity<Country>().HasData(new {
            Id = "3d4bde3f-9d6f-4882-9398-4e5df284dd19",
            Name = "Eritrea",
            Code2 = "ER",
            Code3 = "ERI",
            Location_Latitude = 15.179384,
            Location_Longitude = 39.782334
         });

         builder.Entity<Country>().HasData(new {
            Id = "e9043d37-7aca-4d97-abd4-439afe4ff536",
            Name = "Estonia",
            Code2 = "EE",
            Code3 = "EST",
            Location_Latitude = 58.595272,
            Location_Longitude = 25.013607
         });

         builder.Entity<Country>().HasData(new {
            Id = "75cf2f58-8b9a-4553-8f68-3a7f2df45ee8",
            Name = "Eswatini",
            Code2 = "SZ",
            Code3 = "SWZ",
            Location_Latitude = -26.522503,
            Location_Longitude = 31.465866
         });

         builder.Entity<Country>().HasData(new {
            Id = "72add91d-b063-4706-a1f5-d999ff751504",
            Name = "Ethiopia",
            Code2 = "ET",
            Code3 = "ETH",
            Location_Latitude = 9.145,
            Location_Longitude = 40.489673
         });

         builder.Entity<Country>().HasData(new {
            Id = "9f550658-c521-474d-9aae-65c12effc11f",
            Name = "Falkland Islands (Malvinas)",
            Code2 = "FK",
            Code3 = "FLK",
            Location_Latitude = -51.796253,
            Location_Longitude = -59.523613
         });

         builder.Entity<Country>().HasData(new {
            Id = "e9a63c1a-6d15-435e-8705-3cfaeb443571",
            Name = "Faroe Islands",
            Code2 = "FO",
            Code3 = "FRO",
            Location_Latitude = 61.892635,
            Location_Longitude = -6.911806
         });

         builder.Entity<Country>().HasData(new {
            Id = "c54d79f7-b117-45a1-a09e-066542bf9e3d",
            Name = "Fiji",
            Code2 = "FJ",
            Code3 = "FJI",
            Location_Latitude = -16.578193,
            Location_Longitude = 179.414413
         });

         builder.Entity<Country>().HasData(new {
            Id = "8057be7d-9e49-4721-9872-b3274dab1a50",
            Name = "Finland",
            Code2 = "FI",
            Code3 = "FIN",
            Location_Latitude = 61.92411,
            Location_Longitude = 25.748151
         });

         builder.Entity<Country>().HasData(new {
            Id = "c87f2f17-8557-48ee-ac18-f94e0ea13c81",
            Name = "France",
            Code2 = "FR",
            Code3 = "FRA",
            Location_Latitude = 46.227638,
            Location_Longitude = 2.213749
         });

         builder.Entity<Country>().HasData(new {
            Id = "835f5ef4-c339-471d-bac1-694af0323a9b",
            Name = "French Guiana",
            Code2 = "GF",
            Code3 = "GUF",
            Location_Latitude = 3.933889,
            Location_Longitude = -53.125782
         });

         builder.Entity<Country>().HasData(new {
            Id = "c07e0f0c-158f-4ba6-b953-f9b7faa31516",
            Name = "French Polynesia",
            Code2 = "PF",
            Code3 = "PYF",
            Location_Latitude = -17.679742,
            Location_Longitude = -149.406843
         });

         builder.Entity<Country>().HasData(new {
            Id = "e14e9227-0f97-473f-8008-095572d8de4c",
            Name = "French Southern Territories",
            Code2 = "TF",
            Code3 = "ATF",
            Location_Latitude = -49.280366,
            Location_Longitude = 69.348557
         });

         builder.Entity<Country>().HasData(new {
            Id = "6650ed21-db40-4554-a965-28f2e34ed808",
            Name = "Gabon",
            Code2 = "GA",
            Code3 = "GAB",
            Location_Latitude = -0.803689,
            Location_Longitude = 11.609444
         });

         builder.Entity<Country>().HasData(new {
            Id = "b7c25e29-2a59-4882-8a36-9aed9fe4de1c",
            Name = "Gambia",
            Code2 = "GM",
            Code3 = "GMB",
            Location_Latitude = 13.443182,
            Location_Longitude = -15.310139
         });

         builder.Entity<Country>().HasData(new {
            Id = "a1460ffe-64ad-408e-9b37-990f0d36c697",
            Name = "Georgia",
            Code2 = "GE",
            Code3 = "GEO",
            Location_Latitude = 42.315407,
            Location_Longitude = 43.356892
         });

         builder.Entity<Country>().HasData(new {
            Id = "b8ca640b-0a6b-4c29-bd4a-9a8c76d4ccb2",
            Name = "Germany",
            Code2 = "DE",
            Code3 = "DEU",
            Location_Latitude = 51.165691,
            Location_Longitude = 10.451526
         });

         builder.Entity<Country>().HasData(new {
            Id = "4d22d98a-fcc1-4b4a-aa57-749ea8decf0d",
            Name = "Ghana",
            Code2 = "GH",
            Code3 = "GHA",
            Location_Latitude = 7.946527,
            Location_Longitude = -1.023194
         });

         builder.Entity<Country>().HasData(new {
            Id = "25df0670-d028-426c-994e-a5db33614fac",
            Name = "Gibraltar",
            Code2 = "GI",
            Code3 = "GIB",
            Location_Latitude = 36.137741,
            Location_Longitude = -5.345374
         });

         builder.Entity<Country>().HasData(new {
            Id = "9f79f61b-3821-42a5-88fc-687a52fca613",
            Name = "Greece",
            Code2 = "GR",
            Code3 = "GRC",
            Location_Latitude = 39.074208,
            Location_Longitude = 21.824312
         });

         builder.Entity<Country>().HasData(new {
            Id = "4bddbebc-5097-4d2a-9cd7-c2d654d6e7f2",
            Name = "Greenland",
            Code2 = "GL",
            Code3 = "GRL",
            Location_Latitude = 71.706936,
            Location_Longitude = -42.604303
         });

         builder.Entity<Country>().HasData(new {
            Id = "4520c6a8-c0fd-45f5-90a6-4fc78c6f0951",
            Name = "Grenada",
            Code2 = "GD",
            Code3 = "GRD",
            Location_Latitude = 12.262776,
            Location_Longitude = -61.604171
         });

         builder.Entity<Country>().HasData(new {
            Id = "c731f2b6-d69e-4c4a-839d-dc4db2a80369",
            Name = "Guadeloupe",
            Code2 = "GP",
            Code3 = "GLP",
            Location_Latitude = 16.995971,
            Location_Longitude = -62.067641
         });

         builder.Entity<Country>().HasData(new {
            Id = "3230ff87-4f7d-41e1-8be1-bb2d33d3b9a5",
            Name = "Guam",
            Code2 = "GU",
            Code3 = "GUM",
            Location_Latitude = 13.444304,
            Location_Longitude = 144.793731
         });

         builder.Entity<Country>().HasData(new {
            Id = "ffbcc443-d529-4427-ae47-024c6fd6ece8",
            Name = "Guatemala",
            Code2 = "GT",
            Code3 = "GTM",
            Location_Latitude = 15.783471,
            Location_Longitude = -90.230759
         });

         builder.Entity<Country>().HasData(new {
            Id = "d4f95491-d7c2-4919-8d19-f87e22dca34f",
            Name = "Guernsey",
            Code2 = "GG",
            Code3 = "GGY",
            Location_Latitude = 49.465691,
            Location_Longitude = -2.585278
         });

         builder.Entity<Country>().HasData(new {
            Id = "9aa0c3eb-97ab-46c2-8909-9b6d7a3b34e5",
            Name = "Guinea",
            Code2 = "GN",
            Code3 = "GIN",
            Location_Latitude = 9.945587,
            Location_Longitude = -9.696645
         });

         builder.Entity<Country>().HasData(new {
            Id = "1e8bd3f1-a52d-4d75-bb58-a2146255a792",
            Name = "Guinea-Bissau",
            Code2 = "GW",
            Code3 = "GNB",
            Location_Latitude = 11.803749,
            Location_Longitude = -15.180413
         });

         builder.Entity<Country>().HasData(new {
            Id = "0c82439e-e73f-43c9-8651-01f4f30a2521",
            Name = "Guyana",
            Code2 = "GY",
            Code3 = "GUY",
            Location_Latitude = 4.860416,
            Location_Longitude = -58.93018
         });

         builder.Entity<Country>().HasData(new {
            Id = "5de8d9d5-1be5-4d14-b391-8dfedfb4f23f",
            Name = "Haiti",
            Code2 = "HT",
            Code3 = "HTI",
            Location_Latitude = 18.971187,
            Location_Longitude = -72.285215
         });

         builder.Entity<Country>().HasData(new {
            Id = "4e4c0446-5fc0-4811-8536-9b3f23344616",
            Name = "Heard Island and McDonald Islands",
            Code2 = "HM",
            Code3 = "HMD",
            Location_Latitude = -53.08181,
            Location_Longitude = 73.504158
         });

         builder.Entity<Country>().HasData(new {
            Id = "6aa16a10-71ad-4bf6-a4d0-80095a9d92b2",
            Name = "Holy See",
            Code2 = "VA",
            Code3 = "VAT",
            Location_Latitude = 41.902916,
            Location_Longitude = 12.453389
         });

         builder.Entity<Country>().HasData(new {
            Id = "e767804c-cb3f-4502-bc0f-b732208014ff",
            Name = "Honduras",
            Code2 = "HN",
            Code3 = "HND",
            Location_Latitude = 15.199999,
            Location_Longitude = -86.241905
         });

         builder.Entity<Country>().HasData(new {
            Id = "b8818db5-8922-4f7a-82d9-0141ad4a45a5",
            Name = "Hong Kong",
            Code2 = "HK",
            Code3 = "HKG",
            Location_Latitude = 22.396428,
            Location_Longitude = 114.109497
         });

         builder.Entity<Country>().HasData(new {
            Id = "4725a19c-3abe-4609-b65a-01a9c47f2d89",
            Name = "Hungary",
            Code2 = "HU",
            Code3 = "HUN",
            Location_Latitude = 47.162494,
            Location_Longitude = 19.503304
         });

         builder.Entity<Country>().HasData(new {
            Id = "25efcfa1-b91a-4bcb-b153-406651565651",
            Name = "Iceland",
            Code2 = "IS",
            Code3 = "ISL",
            Location_Latitude = 64.963051,
            Location_Longitude = -19.020835
         });

         builder.Entity<Country>().HasData(new {
            Id = "54031f93-dfeb-43fe-b2d5-27b16e105d7b",
            Name = "India",
            Code2 = "IN",
            Code3 = "IND",
            Location_Latitude = 20.593684,
            Location_Longitude = 78.96288
         });

         builder.Entity<Country>().HasData(new {
            Id = "e7039d66-7d6c-4f42-b5f1-6a79287c098d",
            Name = "Indonesia",
            Code2 = "ID",
            Code3 = "IDN",
            Location_Latitude = -0.789275,
            Location_Longitude = 113.921327
         });

         builder.Entity<Country>().HasData(new {
            Id = "e696352f-5a53-4b81-9109-0fab91ea1956",
            Name = "Iran (Islamic Republic of)",
            Code2 = "IR",
            Code3 = "IRN",
            Location_Latitude = 32.427908,
            Location_Longitude = 53.688046
         });

         builder.Entity<Country>().HasData(new {
            Id = "68c633b0-a50e-4b26-b787-addf353fa502",
            Name = "Iran",
            Code2 = "IR",
            Code3 = "IRN",
            Location_Latitude = 32.427908,
            Location_Longitude = 53.688046
         });

         builder.Entity<Country>().HasData(new {
            Id = "b320d017-bb3b-48c4-8871-fe2cf1d6f8ac",
            Name = "Iraq",
            Code2 = "IQ",
            Code3 = "IRQ",
            Location_Latitude = 33.223191,
            Location_Longitude = 43.679291
         });

         builder.Entity<Country>().HasData(new {
            Id = "1c91fb93-cbc0-4194-9a52-5fa839853034",
            Name = "Ireland",
            Code2 = "IE",
            Code3 = "IRL",
            Location_Latitude = 53.41291,
            Location_Longitude = -8.24389
         });

         builder.Entity<Country>().HasData(new {
            Id = "0d9ab580-6175-468c-8318-9101445cd543",
            Name = "Isle of Man",
            Code2 = "IM",
            Code3 = "IMN",
            Location_Latitude = 54.236107,
            Location_Longitude = -4.548056
         });

         builder.Entity<Country>().HasData(new {
            Id = "d738d352-9e4e-4222-b252-0eb3634e0228",
            Name = "Israel",
            Code2 = "IL",
            Code3 = "ISR",
            Location_Latitude = 31.046051,
            Location_Longitude = 34.851612
         });

         builder.Entity<Country>().HasData(new {
            Id = "e9e9e670-a51b-4743-a0f3-bed2451b564c",
            Name = "Italy",
            Code2 = "IT",
            Code3 = "ITA",
            Location_Latitude = 41.87194,
            Location_Longitude = 12.56738
         });

         builder.Entity<Country>().HasData(new {
            Id = "05abe794-8f0c-43ae-8305-9ac04d3a0830",
            Name = "Jamaica",
            Code2 = "JM",
            Code3 = "JAM",
            Location_Latitude = 18.109581,
            Location_Longitude = -77.297508
         });

         builder.Entity<Country>().HasData(new {
            Id = "b7de5e6b-a00e-453a-992e-5d95680a0179",
            Name = "Japan",
            Code2 = "JP",
            Code3 = "JPN",
            Location_Latitude = 36.204824,
            Location_Longitude = 138.252924
         });

         builder.Entity<Country>().HasData(new {
            Id = "8687d0b7-0890-4ab6-a57e-8361220707ee",
            Name = "Jersey",
            Code2 = "JE",
            Code3 = "JEY",
            Location_Latitude = 49.214439,
            Location_Longitude = -2.13125
         });

         builder.Entity<Country>().HasData(new {
            Id = "5f1a49be-f5da-42d7-b728-5e9fd068ec1a",
            Name = "Jordan",
            Code2 = "JO",
            Code3 = "JOR",
            Location_Latitude = 30.585164,
            Location_Longitude = 36.238414
         });

         builder.Entity<Country>().HasData(new {
            Id = "0411bfb0-4b68-461a-a4d7-7f3997242a3c",
            Name = "Kazakhstan",
            Code2 = "KZ",
            Code3 = "KAZ",
            Location_Latitude = 48.019573,
            Location_Longitude = 66.923684
         });

         builder.Entity<Country>().HasData(new {
            Id = "5dcee40a-98b3-46fe-9e94-4aeac8c9cb2f",
            Name = "Kenya",
            Code2 = "KE",
            Code3 = "KEN",
            Location_Latitude = -0.023559,
            Location_Longitude = 37.906193
         });

         builder.Entity<Country>().HasData(new {
            Id = "27f97629-1fa5-4fcd-8c58-8719f25080cb",
            Name = "Kiribati",
            Code2 = "KI",
            Code3 = "KIR",
            Location_Latitude = -3.370417,
            Location_Longitude = -168.734039
         });

         builder.Entity<Country>().HasData(new {
            Id = "1095ec61-6139-47ed-8d89-a814df34417d",
            Name = "Korea (Democratic People's Republic of)",
            Code2 = "KP",
            Code3 = "PRK",
            Location_Latitude = 40.339852,
            Location_Longitude = 127.510093
         });

         builder.Entity<Country>().HasData(new {
            Id = "2f59b79e-ebcc-4a19-9641-e020ebaee3cd",
            Name = "Korea (Republic of)",
            Code2 = "KR",
            Code3 = "KOR",
            Location_Latitude = 35.907757,
            Location_Longitude = 127.766922
         });

         builder.Entity<Country>().HasData(new {
            Id = "8822f89f-9246-4289-a96a-d8a176f6cf74",
            Name = "Korea",
            Code2 = "KR",
            Code3 = "KOR",
            Location_Latitude = 35.907757,
            Location_Longitude = 127.766922
         });

         builder.Entity<Country>().HasData(new {
            Id = "13fbff1b-6c8d-41ee-9a21-15a24a9ab733",
            Name = "Kuwait",
            Code2 = "KW",
            Code3 = "KWT",
            Location_Latitude = 29.31166,
            Location_Longitude = 47.481766
         });

         builder.Entity<Country>().HasData(new {
            Id = "623ffb3b-4182-4462-9665-9e798960c885",
            Name = "Kyrgyzstan",
            Code2 = "KG",
            Code3 = "KGZ",
            Location_Latitude = 41.20438,
            Location_Longitude = 74.766098
         });

         builder.Entity<Country>().HasData(new {
            Id = "d95a00c5-a2bd-4d1f-bce7-5f28a2261305",
            Name = "Lao People's Democratic Republic",
            Code2 = "LA",
            Code3 = "LAO",
            Location_Latitude = 19.85627,
            Location_Longitude = 102.495496
         });

         builder.Entity<Country>().HasData(new {
            Id = "ee9fbb8c-76ce-4a0b-93cd-83eeafe15178",
            Name = "Laos",
            Code2 = "LA",
            Code3 = "LAO",
            Location_Latitude = 19.85627,
            Location_Longitude = 102.495496
         });

         builder.Entity<Country>().HasData(new {
            Id = "c39d6350-8857-433a-8c11-6c474c09ad7f",
            Name = "Latvia",
            Code2 = "LV",
            Code3 = "LVA",
            Location_Latitude = 56.879635,
            Location_Longitude = 24.603189
         });

         builder.Entity<Country>().HasData(new {
            Id = "ab502518-caa8-4416-92f6-c22002ba19a0",
            Name = "Lebanon",
            Code2 = "LB",
            Code3 = "LBN",
            Location_Latitude = 33.854721,
            Location_Longitude = 35.862285
         });

         builder.Entity<Country>().HasData(new {
            Id = "eebde06a-be06-4c55-bdaf-c1f3256456d4",
            Name = "Lesotho",
            Code2 = "LS",
            Code3 = "LSO",
            Location_Latitude = -29.609988,
            Location_Longitude = 28.233608
         });

         builder.Entity<Country>().HasData(new {
            Id = "eeff84da-34b4-4509-b842-fb49031d7c91",
            Name = "Liberia",
            Code2 = "LR",
            Code3 = "LBR",
            Location_Latitude = 6.428055,
            Location_Longitude = -9.429499
         });

         builder.Entity<Country>().HasData(new {
            Id = "ecd2807b-21b8-48ea-990a-0545740e50d7",
            Name = "Libya",
            Code2 = "LY",
            Code3 = "LBY",
            Location_Latitude = 26.3351,
            Location_Longitude = 17.228331
         });

         builder.Entity<Country>().HasData(new {
            Id = "f162f8fa-ab82-43ef-9e98-f57d879d2ea2",
            Name = "Liechtenstein",
            Code2 = "LI",
            Code3 = "LIE",
            Location_Latitude = 47.166,
            Location_Longitude = 9.555373
         });

         builder.Entity<Country>().HasData(new {
            Id = "c5a72efb-9905-4de0-9ab7-b599aced788d",
            Name = "Lithuania",
            Code2 = "LT",
            Code3 = "LTU",
            Location_Latitude = 55.169438,
            Location_Longitude = 23.881275
         });

         builder.Entity<Country>().HasData(new {
            Id = "1dedcb24-ffce-4294-93c5-514d66fba942",
            Name = "Luxembourg",
            Code2 = "LU",
            Code3 = "LUX",
            Location_Latitude = 49.815273,
            Location_Longitude = 6.129583
         });

         builder.Entity<Country>().HasData(new {
            Id = "0015a40a-a493-41e2-aebe-cbccd867c68c",
            Name = "Macao",
            Code2 = "MO",
            Code3 = "MAC",
            Location_Latitude = 22.198745,
            Location_Longitude = 113.543873
         });

         builder.Entity<Country>().HasData(new {
            Id = "67ef12fb-6c70-4763-bfc6-34575cfd6012",
            Name = "Macedonia (the former Yugoslav Republic of)",
            Code2 = "MK",
            Code3 = "MKD",
            Location_Latitude = 41.608635,
            Location_Longitude = 21.745275
         });

         builder.Entity<Country>().HasData(new {
            Id = "c694b105-20f7-49ae-b621-86d06de1a29c",
            Name = "Macedonia",
            Code2 = "MK",
            Code3 = "MKD",
            Location_Latitude = 41.608635,
            Location_Longitude = 21.745275
         });

         builder.Entity<Country>().HasData(new {
            Id = "3ca9a491-009d-4432-9551-6a52e97c9b21",
            Name = "Madagascar",
            Code2 = "MG",
            Code3 = "MDG",
            Location_Latitude = -18.766947,
            Location_Longitude = 46.869107
         });

         builder.Entity<Country>().HasData(new {
            Id = "6cb29817-ac30-43af-a691-7e6220b3d415",
            Name = "Malawi",
            Code2 = "MW",
            Code3 = "MWI",
            Location_Latitude = -13.254308,
            Location_Longitude = 34.301525
         });

         builder.Entity<Country>().HasData(new {
            Id = "5ca6b9d9-1c11-4b6c-b2b3-00a067ca3bb1",
            Name = "Malaysia",
            Code2 = "MY",
            Code3 = "MYS",
            Location_Latitude = 4.210484,
            Location_Longitude = 101.975766
         });

         builder.Entity<Country>().HasData(new {
            Id = "bfafec54-ee78-4e3c-8fb0-d677c6420ed4",
            Name = "Maldives",
            Code2 = "MV",
            Code3 = "MDV",
            Location_Latitude = 3.202778,
            Location_Longitude = 73.22068
         });

         builder.Entity<Country>().HasData(new {
            Id = "ea98b43b-379b-4860-862e-b3876b23ee08",
            Name = "Mali",
            Code2 = "ML",
            Code3 = "MLI",
            Location_Latitude = 17.570692,
            Location_Longitude = -3.996166
         });

         builder.Entity<Country>().HasData(new {
            Id = "c54afedf-fe46-49cb-baca-53ec0892d4a5",
            Name = "Malta",
            Code2 = "MT",
            Code3 = "MLT",
            Location_Latitude = 35.937496,
            Location_Longitude = 14.375416
         });

         builder.Entity<Country>().HasData(new {
            Id = "e3385e5e-b497-4121-8c58-5f974f47f598",
            Name = "Marshall Islands",
            Code2 = "MH",
            Code3 = "MHL",
            Location_Latitude = 7.131474,
            Location_Longitude = 171.184478
         });

         builder.Entity<Country>().HasData(new {
            Id = "f71999a7-0183-41b1-af60-28cae942e45e",
            Name = "Martinique",
            Code2 = "MQ",
            Code3 = "MTQ",
            Location_Latitude = 14.641528,
            Location_Longitude = -61.024174
         });

         builder.Entity<Country>().HasData(new {
            Id = "32585d9f-0bfa-4b0d-b28a-6633fc9e2a57",
            Name = "Mauritania",
            Code2 = "MR",
            Code3 = "MRT",
            Location_Latitude = 21.00789,
            Location_Longitude = -10.940835
         });

         builder.Entity<Country>().HasData(new {
            Id = "8e750165-45d0-4608-9fe0-fffcd0b497ac",
            Name = "Mauritius",
            Code2 = "MU",
            Code3 = "MUS",
            Location_Latitude = -20.348404,
            Location_Longitude = 57.552152
         });

         builder.Entity<Country>().HasData(new {
            Id = "deedbc18-ece9-49e7-b9c8-45721cc6c044",
            Name = "Mayotte",
            Code2 = "YT",
            Code3 = "MYT",
            Location_Latitude = -12.8275,
            Location_Longitude = 45.166244
         });

         builder.Entity<Country>().HasData(new {
            Id = "ab87ae59-f9c7-4fce-bf2d-21895e0337d4",
            Name = "Mexico",
            Code2 = "MX",
            Code3 = "MEX",
            Location_Latitude = 23.634501,
            Location_Longitude = -102.552784
         });

         builder.Entity<Country>().HasData(new {
            Id = "59d96296-7a8c-41e2-9288-e38280542bd9",
            Name = "Micronesia (Federated States of)",
            Code2 = "FM",
            Code3 = "FSM",
            Location_Latitude = 7.425554,
            Location_Longitude = 150.550812
         });

         builder.Entity<Country>().HasData(new {
            Id = "463b405f-7d27-4e31-88d0-f66c7e5a08c1",
            Name = "Moldova (Republic of)",
            Code2 = "MD",
            Code3 = "MDA",
            Location_Latitude = 47.411631,
            Location_Longitude = 28.369885
         });

         builder.Entity<Country>().HasData(new {
            Id = "6220e302-7f3e-4c65-921d-b570b0da87be",
            Name = "Monaco",
            Code2 = "MC",
            Code3 = "MCO",
            Location_Latitude = 43.750298,
            Location_Longitude = 7.412841
         });

         builder.Entity<Country>().HasData(new {
            Id = "8f1fb492-938a-4e4b-80b1-00588acb1ba5",
            Name = "Mongolia",
            Code2 = "MN",
            Code3 = "MNG",
            Location_Latitude = 46.862496,
            Location_Longitude = 103.846656
         });

         builder.Entity<Country>().HasData(new {
            Id = "d1e98f47-be26-491f-a345-ba094b0d09c7",
            Name = "Montenegro",
            Code2 = "ME",
            Code3 = "MNE",
            Location_Latitude = 42.708678,
            Location_Longitude = 19.37439
         });

         builder.Entity<Country>().HasData(new {
            Id = "7694799d-5d0a-4131-a84b-72b74ed6992f",
            Name = "Montserrat",
            Code2 = "MS",
            Code3 = "MSR",
            Location_Latitude = 16.742498,
            Location_Longitude = -62.187366
         });

         builder.Entity<Country>().HasData(new {
            Id = "eedb87e3-450d-485b-b285-9b222bd2228c",
            Name = "Morocco",
            Code2 = "MA",
            Code3 = "MAR",
            Location_Latitude = 31.791702,
            Location_Longitude = -7.09262
         });

         builder.Entity<Country>().HasData(new {
            Id = "66556adb-f36c-471b-917f-fce7cc573b24",
            Name = "Mozambique",
            Code2 = "MZ",
            Code3 = "MOZ",
            Location_Latitude = -18.665695,
            Location_Longitude = 35.529562
         });

         builder.Entity<Country>().HasData(new {
            Id = "e366c7a4-1622-42b8-91ec-eb08e05c9e5d",
            Name = "Myanmar",
            Code2 = "MM",
            Code3 = "MMR",
            Location_Latitude = 21.913965,
            Location_Longitude = 95.956223
         });

         builder.Entity<Country>().HasData(new {
            Id = "e4c7f11c-6e2c-426f-9a43-a7390788393f",
            Name = "Namibia",
            Code2 = "NA",
            Code3 = "NAM",
            Location_Latitude = -22.95764,
            Location_Longitude = 18.49041
         });

         builder.Entity<Country>().HasData(new {
            Id = "ad87db55-a77a-4896-af59-15bf504c1af0",
            Name = "Nauru",
            Code2 = "NR",
            Code3 = "NRU",
            Location_Latitude = -0.522778,
            Location_Longitude = 166.931503
         });

         builder.Entity<Country>().HasData(new {
            Id = "f00a13db-1aca-42d7-a10c-02a0a88cdf80",
            Name = "Nepal",
            Code2 = "NP",
            Code3 = "NPL",
            Location_Latitude = 28.394857,
            Location_Longitude = 84.124008
         });

         builder.Entity<Country>().HasData(new {
            Id = "d7b4a62a-e4bf-4ea7-ab68-87c8fadfa0d6",
            Name = "Netherlands",
            Code2 = "NL",
            Code3 = "NLD",
            Location_Latitude = 52.132633,
            Location_Longitude = 5.291266
         });

         builder.Entity<Country>().HasData(new {
            Id = "c9333810-a097-4a75-b0c5-afd22f6863c4",
            Name = "New Caledonia",
            Code2 = "NC",
            Code3 = "NCL",
            Location_Latitude = -20.904305,
            Location_Longitude = 165.618042
         });

         builder.Entity<Country>().HasData(new {
            Id = "553af18b-f5a7-4d8d-aa77-573297891ad8",
            Name = "New Zealand",
            Code2 = "NZ",
            Code3 = "NZL",
            Location_Latitude = -40.900557,
            Location_Longitude = 174.885971
         });

         builder.Entity<Country>().HasData(new {
            Id = "b515fcf8-601b-4464-89dd-1c1e5d7a1098",
            Name = "Nicaragua",
            Code2 = "NI",
            Code3 = "NIC",
            Location_Latitude = 12.865416,
            Location_Longitude = -85.207229
         });

         builder.Entity<Country>().HasData(new {
            Id = "6a80d61b-344f-4cd0-84b1-d8df1d447fde",
            Name = "Niger",
            Code2 = "NE",
            Code3 = "NER",
            Location_Latitude = 17.607789,
            Location_Longitude = 8.081666
         });

         builder.Entity<Country>().HasData(new {
            Id = "9eb55e10-f386-4d0e-9d3f-6e763970dbec",
            Name = "Nigeria",
            Code2 = "NG",
            Code3 = "NGA",
            Location_Latitude = 9.081999,
            Location_Longitude = 8.675277
         });

         builder.Entity<Country>().HasData(new {
            Id = "52849ef9-6ad6-4f4c-bbca-98a841736311",
            Name = "Niue",
            Code2 = "NU",
            Code3 = "NIU",
            Location_Latitude = -19.054445,
            Location_Longitude = -169.867233
         });

         builder.Entity<Country>().HasData(new {
            Id = "2e6970b6-d5dd-4589-ba8b-393dae6aadc6",
            Name = "Norfolk Island",
            Code2 = "NF",
            Code3 = "NFK",
            Location_Latitude = -29.040835,
            Location_Longitude = 167.954712
         });

         builder.Entity<Country>().HasData(new {
            Id = "56998bee-caeb-4f2b-ae60-51de18e7d744",
            Name = "Northern Mariana Islands",
            Code2 = "MP",
            Code3 = "MNP",
            Location_Latitude = 17.33083,
            Location_Longitude = 145.38469
         });

         builder.Entity<Country>().HasData(new {
            Id = "497497c7-c13d-40bf-bda6-8cfe8efc1068",
            Name = "Norway",
            Code2 = "NO",
            Code3 = "NOR",
            Location_Latitude = 60.472024,
            Location_Longitude = 8.468946
         });

         builder.Entity<Country>().HasData(new {
            Id = "1b8259c4-eef8-4ac2-bcea-6e0d46d5bc42",
            Name = "Oman",
            Code2 = "OM",
            Code3 = "OMN",
            Location_Latitude = 21.512583,
            Location_Longitude = 55.923255
         });

         builder.Entity<Country>().HasData(new {
            Id = "93605d6b-a2ba-4d7a-bb51-8acb08e5bd1a",
            Name = "Pakistan",
            Code2 = "PK",
            Code3 = "PAK",
            Location_Latitude = 30.375321,
            Location_Longitude = 69.345116
         });

         builder.Entity<Country>().HasData(new {
            Id = "9f6d3e75-cd21-409f-9173-aca90f9b93f3",
            Name = "Palau",
            Code2 = "PW",
            Code3 = "PLW",
            Location_Latitude = 7.51498,
            Location_Longitude = 134.58252
         });

         builder.Entity<Country>().HasData(new {
            Id = "9feb70b9-80a2-4b12-96ea-62d423af00f0",
            Name = "Palestine, State of",
            Code2 = "PS",
            Code3 = "PSE",
            Location_Latitude = 31.952162,
            Location_Longitude = 35.233154
         });

         builder.Entity<Country>().HasData(new {
            Id = "9ef3163e-a0b7-4967-ae61-a87b5b5c19bc",
            Name = "Panama",
            Code2 = "PA",
            Code3 = "PAN",
            Location_Latitude = 8.537981,
            Location_Longitude = -80.782127
         });

         builder.Entity<Country>().HasData(new {
            Id = "33084585-3273-46ca-8fc7-b169f03dd1b8",
            Name = "Papua New Guinea",
            Code2 = "PG",
            Code3 = "PNG",
            Location_Latitude = -6.314993,
            Location_Longitude = 143.95555
         });

         builder.Entity<Country>().HasData(new {
            Id = "33edd49d-df1c-40c0-a098-4a5c369e23a3",
            Name = "Paraguay",
            Code2 = "PY",
            Code3 = "PRY",
            Location_Latitude = -23.442503,
            Location_Longitude = -58.443832
         });

         builder.Entity<Country>().HasData(new {
            Id = "57eedc31-71b7-44bc-aca0-2b3ff9e64361",
            Name = "Peru",
            Code2 = "PE",
            Code3 = "PER",
            Location_Latitude = -9.189967,
            Location_Longitude = -75.015152
         });

         builder.Entity<Country>().HasData(new {
            Id = "ec195e19-a5f9-4ab3-a0d7-50174fb14dc8",
            Name = "Philippines",
            Code2 = "PH",
            Code3 = "PHL",
            Location_Latitude = 12.879721,
            Location_Longitude = 121.774017
         });

         builder.Entity<Country>().HasData(new {
            Id = "dd1095a3-0b66-41ae-a3ba-2f415b7839b2",
            Name = "Pitcairn",
            Code2 = "PN",
            Code3 = "PCN",
            Location_Latitude = -24.703615,
            Location_Longitude = -127.439308
         });

         builder.Entity<Country>().HasData(new {
            Id = "13e332cd-aa81-410d-b18c-ad95b6b13663",
            Name = "Poland",
            Code2 = "PL",
            Code3 = "POL",
            Location_Latitude = 51.919438,
            Location_Longitude = 19.145136
         });

         builder.Entity<Country>().HasData(new {
            Id = "5e288331-46de-49f9-a1be-896fb4e5cffa",
            Name = "Portugal",
            Code2 = "PT",
            Code3 = "PRT",
            Location_Latitude = 39.399872,
            Location_Longitude = -8.224454
         });

         builder.Entity<Country>().HasData(new {
            Id = "73a60e18-9dbe-4f74-8353-5c5568e572c8",
            Name = "Puerto Rico",
            Code2 = "PR",
            Code3 = "PRI",
            Location_Latitude = 18.220833,
            Location_Longitude = -66.590149
         });

         builder.Entity<Country>().HasData(new {
            Id = "bcd0422f-1de7-4e28-aa0f-08df50134a83",
            Name = "Qatar",
            Code2 = "QA",
            Code3 = "QAT",
            Location_Latitude = 25.354826,
            Location_Longitude = 51.183884
         });

         builder.Entity<Country>().HasData(new {
            Id = "39ab367c-b9e6-46a3-be15-132677ab2ab3",
            Name = "Réunion",
            Code2 = "RE",
            Code3 = "REU",
            Location_Latitude = -21.115141,
            Location_Longitude = 55.536384
         });

         builder.Entity<Country>().HasData(new {
            Id = "325b9be0-826c-432a-aacc-4a8db883567f",
            Name = "Reunion",
            Code2 = "RE",
            Code3 = "REU",
            Location_Latitude = -21.115141,
            Location_Longitude = 55.536384
         });

         builder.Entity<Country>().HasData(new {
            Id = "4b2947f4-4d12-47c3-9d57-a8ba8df11ccb",
            Name = "Romania",
            Code2 = "RO",
            Code3 = "ROU",
            Location_Latitude = 45.943161,
            Location_Longitude = 24.96676
         });

         builder.Entity<Country>().HasData(new {
            Id = "f4830d35-f82d-4d0a-889c-7500e6e40973",
            Name = "Russian Federation",
            Code2 = "RU",
            Code3 = "RUS",
            Location_Latitude = 61.52401,
            Location_Longitude = 105.318756
         });

         builder.Entity<Country>().HasData(new {
            Id = "e8fe4d7a-f640-4c2f-8de2-dd64552074cb",
            Name = "Russia",
            Code2 = "RU",
            Code3 = "RUS",
            Location_Latitude = 61.52401,
            Location_Longitude = 105.318756
         });

         builder.Entity<Country>().HasData(new {
            Id = "5387a1a4-d6ae-43cd-b343-e5f2be6af1ea",
            Name = "Rwanda",
            Code2 = "RW",
            Code3 = "RWA",
            Location_Latitude = -1.940278,
            Location_Longitude = 29.873888
         });

         builder.Entity<Country>().HasData(new {
            Id = "54478e1d-a6b7-4c1c-97c1-4d82ede303f6",
            Name = "Saint Barthélemy",
            Code2 = "BL",
            Code3 = "BLM",
            Location_Latitude = 0,
            Location_Longitude = 0
         });

         builder.Entity<Country>().HasData(new {
            Id = "f370ac01-e25a-460a-b95e-fb4e97180f5c",
            Name = "Saint Helena, Ascension and Tristan da Cunha",
            Code2 = "SH",
            Code3 = "SHN",
            Location_Latitude = -24.143474,
            Location_Longitude = -10.030696
         });

         builder.Entity<Country>().HasData(new {
            Id = "906fd092-01ed-40a7-a01e-6f51dd72762d",
            Name = "Saint Kitts and Nevis",
            Code2 = "KN",
            Code3 = "KNA",
            Location_Latitude = 17.357822,
            Location_Longitude = -62.782998
         });

         builder.Entity<Country>().HasData(new {
            Id = "3a70a768-03fc-4870-9509-9275ab7110b0",
            Name = "Saint Lucia",
            Code2 = "LC",
            Code3 = "LCA",
            Location_Latitude = 13.909444,
            Location_Longitude = -60.978893
         });

         builder.Entity<Country>().HasData(new {
            Id = "192f49dc-d414-4c45-9b3c-8d90b3f394ee",
            Name = "Saint Martin (French part)",
            Code2 = "MF",
            Code3 = "MAF",
            Location_Latitude = 0,
            Location_Longitude = 0
         });

         builder.Entity<Country>().HasData(new {
            Id = "2355a54e-a7f4-4318-871a-38d6edd75207",
            Name = "Saint Pierre and Miquelon",
            Code2 = "PM",
            Code3 = "SPM",
            Location_Latitude = 46.941936,
            Location_Longitude = -56.27111
         });

         builder.Entity<Country>().HasData(new {
            Id = "b582ecd6-a1cf-427d-8bb8-042e0e0aed87",
            Name = "Saint Vincent and the Grenadines",
            Code2 = "VC",
            Code3 = "VCT",
            Location_Latitude = 12.984305,
            Location_Longitude = -61.287228
         });

         builder.Entity<Country>().HasData(new {
            Id = "7f2d7293-2403-45d6-90c0-509842bc1692",
            Name = "Samoa",
            Code2 = "WS",
            Code3 = "WSM",
            Location_Latitude = -13.759029,
            Location_Longitude = -172.104629
         });

         builder.Entity<Country>().HasData(new {
            Id = "68b82b62-fbdc-4ba3-8077-db71f2c8a249",
            Name = "San Marino",
            Code2 = "SM",
            Code3 = "SMR",
            Location_Latitude = 43.94236,
            Location_Longitude = 12.457777
         });

         builder.Entity<Country>().HasData(new {
            Id = "b0d1a2c9-16b7-445d-8dc9-c1c1ec13d561",
            Name = "Sao Tome and Principe",
            Code2 = "ST",
            Code3 = "STP",
            Location_Latitude = 0.18636,
            Location_Longitude = 6.613081
         });

         builder.Entity<Country>().HasData(new {
            Id = "37e82658-5623-497e-aad4-9a62d8912f3b",
            Name = "Saudi Arabia",
            Code2 = "SA",
            Code3 = "SAU",
            Location_Latitude = 23.885942,
            Location_Longitude = 45.079162
         });

         builder.Entity<Country>().HasData(new {
            Id = "f3bbbf8f-b177-4a1a-94f3-c333a5c11391",
            Name = "Senegal",
            Code2 = "SN",
            Code3 = "SEN",
            Location_Latitude = 14.497401,
            Location_Longitude = -14.452362
         });

         builder.Entity<Country>().HasData(new {
            Id = "0806405a-df0b-45a6-8613-788a1af3c621",
            Name = "Serbia",
            Code2 = "RS",
            Code3 = "SRB",
            Location_Latitude = 44.016521,
            Location_Longitude = 21.005859
         });

         builder.Entity<Country>().HasData(new {
            Id = "b5a0b813-c87a-48da-a4a6-8230e9e6bd52",
            Name = "Serbia (Yugoslavia)",
            Code2 = "RS",
            Code3 = "SRB",
            Location_Latitude = 44.016521,
            Location_Longitude = 21.005859
         });

         builder.Entity<Country>().HasData(new {
            Id = "7990469e-7444-4b2b-8b0c-e5370e088840",
            Name = "Seychelles",
            Code2 = "SC",
            Code3 = "SYC",
            Location_Latitude = -4.679574,
            Location_Longitude = 55.491977
         });

         builder.Entity<Country>().HasData(new {
            Id = "023fa312-2e64-448c-a3c3-2f819f15acba",
            Name = "Sierra Leone",
            Code2 = "SL",
            Code3 = "SLE",
            Location_Latitude = 8.460555,
            Location_Longitude = -11.779889
         });

         builder.Entity<Country>().HasData(new {
            Id = "ed4e10a8-3a3d-4651-9f1a-3d51d07b9ab7",
            Name = "Singapore",
            Code2 = "SG",
            Code3 = "SGP",
            Location_Latitude = 1.352083,
            Location_Longitude = 103.819836
         });

         builder.Entity<Country>().HasData(new {
            Id = "e9924300-87ab-41ab-a182-7813e3875c4a",
            Name = "Sint Maarten (Dutch part)",
            Code2 = "SX",
            Code3 = "SXM",
            Location_Latitude = 0,
            Location_Longitude = 0
         });

         builder.Entity<Country>().HasData(new {
            Id = "0ac58dff-6627-46b3-aea9-b80e90155804",
            Name = "Slovakia",
            Code2 = "SK",
            Code3 = "SVK",
            Location_Latitude = 48.669026,
            Location_Longitude = 19.699024
         });

         builder.Entity<Country>().HasData(new {
            Id = "48aaaf32-beb2-4923-9aaa-4c95370b9252",
            Name = "Slovenia",
            Code2 = "SI",
            Code3 = "SVN",
            Location_Latitude = 46.151241,
            Location_Longitude = 14.995463
         });

         builder.Entity<Country>().HasData(new {
            Id = "0e51bcfc-47f4-4488-ac1e-06c6cf4e2b80",
            Name = "Solomon Islands",
            Code2 = "SB",
            Code3 = "SLB",
            Location_Latitude = -9.64571,
            Location_Longitude = 160.156194
         });

         builder.Entity<Country>().HasData(new {
            Id = "d906ae67-c0fe-4f92-b876-a746aaa8bca0",
            Name = "Somalia",
            Code2 = "SO",
            Code3 = "SOM",
            Location_Latitude = 5.152149,
            Location_Longitude = 46.199616
         });

         builder.Entity<Country>().HasData(new {
            Id = "8e4a3dd7-b653-4c95-b450-b8bddb9d6dad",
            Name = "South Africa",
            Code2 = "ZA",
            Code3 = "ZAF",
            Location_Latitude = -30.559482,
            Location_Longitude = 22.937506
         });

         builder.Entity<Country>().HasData(new {
            Id = "85f7d9d9-72a0-49eb-9209-0fba3cfbabc3",
            Name = "South Georgia and the South Sandwich Islands",
            Code2 = "GS",
            Code3 = "SGS",
            Location_Latitude = -54.429579,
            Location_Longitude = -36.587909
         });

         builder.Entity<Country>().HasData(new {
            Id = "6ceb040a-7570-421d-b75f-152cdbe20a19",
            Name = "South Sudan",
            Code2 = "SS",
            Code3 = "SSD",
            Location_Latitude = 0,
            Location_Longitude = 0
         });

         builder.Entity<Country>().HasData(new {
            Id = "d1f3c06a-280a-4e36-a6d0-5d80a3c7ac2d",
            Name = "Spain",
            Code2 = "ES",
            Code3 = "ESP",
            Location_Latitude = 40.463667,
            Location_Longitude = -3.74922
         });

         builder.Entity<Country>().HasData(new {
            Id = "2e940e72-d23a-48ff-9c3c-811610b1556e",
            Name = "España",
            Code2 = "ES",
            Code3 = "ESP",
            Location_Latitude = 40.463667,
            Location_Longitude = -3.74922
         });

         builder.Entity<Country>().HasData(new {
            Id = "92ea4afd-0bd6-4fb4-a984-3ea66497462c",
            Name = "Sri Lanka",
            Code2 = "LK",
            Code3 = "LKA",
            Location_Latitude = 7.873054,
            Location_Longitude = 80.771797
         });

         builder.Entity<Country>().HasData(new {
            Id = "d56e076c-0143-41b0-868b-4a9dc7e5a062",
            Name = "Sudan",
            Code2 = "SD",
            Code3 = "SDN",
            Location_Latitude = 12.862807,
            Location_Longitude = 30.217636
         });

         builder.Entity<Country>().HasData(new {
            Id = "87a92f9a-3b31-45a9-8ff5-06f1b063d0a3",
            Name = "Suriname",
            Code2 = "SR",
            Code3 = "SUR",
            Location_Latitude = 3.919305,
            Location_Longitude = -56.027783
         });

         builder.Entity<Country>().HasData(new {
            Id = "29e60779-dd75-4484-b510-81a6ef1575c7",
            Name = "Svalbard and Jan Mayen",
            Code2 = "SJ",
            Code3 = "SJM",
            Location_Latitude = 77.553604,
            Location_Longitude = 23.670272
         });

         builder.Entity<Country>().HasData(new {
            Id = "c25570bd-0810-4872-9c04-86c0ef0ba2c7",
            Name = "Sweden",
            Code2 = "SE",
            Code3 = "SWE",
            Location_Latitude = 60.128161,
            Location_Longitude = 18.643501
         });

         builder.Entity<Country>().HasData(new {
            Id = "17779450-4593-4630-a455-0c0f84fb703b",
            Name = "Switzerland",
            Code2 = "CH",
            Code3 = "CHE",
            Location_Latitude = 46.818188,
            Location_Longitude = 8.227512
         });

         builder.Entity<Country>().HasData(new {
            Id = "3b2540c5-cc80-48b9-aeb3-d53195ecba11",
            Name = "Syrian Arab Republic",
            Code2 = "SY",
            Code3 = "SYR",
            Location_Latitude = 34.802075,
            Location_Longitude = 38.996815
         });

         builder.Entity<Country>().HasData(new {
            Id = "355fba98-4348-4988-aae6-e327fa3929ac",
            Name = "Syria",
            Code2 = "SY",
            Code3 = "SYR",
            Location_Latitude = 34.802075,
            Location_Longitude = 38.996815
         });

         builder.Entity<Country>().HasData(new {
            Id = "57f0c3c3-673d-49e1-b883-93b08b514c8a",
            Name = "Taiwan, Province of China",
            Code2 = "TW",
            Code3 = "TWN",
            Location_Latitude = 23.69781,
            Location_Longitude = 120.960515
         });

         builder.Entity<Country>().HasData(new {
            Id = "cc857da7-5f46-40d7-a3d2-5a0d5f8ae681",
            Name = "Taiwan",
            Code2 = "TW",
            Code3 = "TWN",
            Location_Latitude = 23.69781,
            Location_Longitude = 120.960515
         });

         builder.Entity<Country>().HasData(new {
            Id = "249ce334-dcd5-44af-a83b-9113f5727a09",
            Name = "Tajikistan",
            Code2 = "TJ",
            Code3 = "TJK",
            Location_Latitude = 38.861034,
            Location_Longitude = 71.276093
         });

         builder.Entity<Country>().HasData(new {
            Id = "88fccb28-b38e-4093-b2e6-b2790ec01e95",
            Name = "Tanzania, United Republic of",
            Code2 = "TZ",
            Code3 = "TZA",
            Location_Latitude = -6.369028,
            Location_Longitude = 34.888822
         });

         builder.Entity<Country>().HasData(new {
            Id = "9cfd90ea-1001-441c-aa9a-6bfbfc3a1b63",
            Name = "Thailand",
            Code2 = "TH",
            Code3 = "THA",
            Location_Latitude = 15.870032,
            Location_Longitude = 100.992541
         });

         builder.Entity<Country>().HasData(new {
            Id = "f78fb1e7-1322-4f77-a166-7d78776f35db",
            Name = "Timor-Leste",
            Code2 = "TL",
            Code3 = "TLS",
            Location_Latitude = -8.874217,
            Location_Longitude = 125.727539
         });

         builder.Entity<Country>().HasData(new {
            Id = "7cb25e94-cbe0-46a4-8f46-b7ae5cd06312",
            Name = "Togo",
            Code2 = "TG",
            Code3 = "TGO",
            Location_Latitude = 8.619543,
            Location_Longitude = 0.824782
         });

         builder.Entity<Country>().HasData(new {
            Id = "c82f03a5-bd89-44a3-87a8-41984e723e38",
            Name = "Tokelau",
            Code2 = "TK",
            Code3 = "TKL",
            Location_Latitude = -8.967363,
            Location_Longitude = -171.855881
         });

         builder.Entity<Country>().HasData(new {
            Id = "6bb35bfd-1af5-4d98-a308-0c4824241a47",
            Name = "Tonga",
            Code2 = "TO",
            Code3 = "TON",
            Location_Latitude = -21.178986,
            Location_Longitude = -175.198242
         });

         builder.Entity<Country>().HasData(new {
            Id = "9cba9cc9-9b55-4407-8158-86c3de455e3c",
            Name = "Trinidad and Tobago",
            Code2 = "TT",
            Code3 = "TTO",
            Location_Latitude = 10.691803,
            Location_Longitude = -61.222503
         });

         builder.Entity<Country>().HasData(new {
            Id = "c805b9a0-9069-4142-a30f-314582da3b7b",
            Name = "Tunisia",
            Code2 = "TN",
            Code3 = "TUN",
            Location_Latitude = 33.886917,
            Location_Longitude = 9.537499
         });

         builder.Entity<Country>().HasData(new {
            Id = "a49e3fb1-f5dd-4ac3-bd2a-586fd3bca53c",
            Name = "Turkey",
            Code2 = "TR",
            Code3 = "TUR",
            Location_Latitude = 38.963745,
            Location_Longitude = 35.243322
         });

         builder.Entity<Country>().HasData(new {
            Id = "847ce96d-7f00-4abb-95f5-8d89887deed8",
            Name = "Turkmenistan",
            Code2 = "TM",
            Code3 = "TKM",
            Location_Latitude = 38.969719,
            Location_Longitude = 59.556278
         });

         builder.Entity<Country>().HasData(new {
            Id = "ca709869-c458-4688-b190-903d7bf65e69",
            Name = "Turks and Caicos Islands",
            Code2 = "TC",
            Code3 = "TCA",
            Location_Latitude = 21.694025,
            Location_Longitude = -71.797928
         });

         builder.Entity<Country>().HasData(new {
            Id = "8b659753-4d5c-42d5-891c-5a52f5f85e64",
            Name = "Tuvalu",
            Code2 = "TV",
            Code3 = "TUV",
            Location_Latitude = -7.109535,
            Location_Longitude = 177.64933
         });

         builder.Entity<Country>().HasData(new {
            Id = "d19bc0f6-bb76-4816-a27f-85258169e92b",
            Name = "Uganda",
            Code2 = "UG",
            Code3 = "UGA",
            Location_Latitude = 1.373333,
            Location_Longitude = 32.290275
         });

         builder.Entity<Country>().HasData(new {
            Id = "b93dca51-d727-442d-ad20-f72e435998a8",
            Name = "Ukraine",
            Code2 = "UA",
            Code3 = "UKR",
            Location_Latitude = 48.379433,
            Location_Longitude = 31.16558
         });

         builder.Entity<Country>().HasData(new {
            Id = "ba49c51b-7e06-4539-ad8b-3f8be3bec319",
            Name = "United Arab Emirates",
            Code2 = "AE",
            Code3 = "ARE",
            Location_Latitude = 23.424076,
            Location_Longitude = 53.847818
         });

         builder.Entity<Country>().HasData(new {
            Id = "92892d5c-732e-48eb-97fa-f0d95670b66b",
            Name = "United Kingdom of Great Britain and Northern Ireland",
            Code2 = "GB",
            Code3 = "GBR",
            Location_Latitude = 55.378051,
            Location_Longitude = -3.435973
         });

         builder.Entity<Country>().HasData(new {
            Id = "ec91b935-16a3-46b9-8d8b-a35720331fd5",
            Name = "United Kingdom",
            Code2 = "GB",
            Code3 = "GBR",
            Location_Latitude = 55.378051,
            Location_Longitude = -3.435973
         });

         builder.Entity<Country>().HasData(new {
            Id = "844cd310-c633-4077-a629-af5c23207319",
            Name = "United States of America",
            Code2 = "US",
            Code3 = "USA",
            Location_Latitude = 37.09024,
            Location_Longitude = -95.712891
         });

         builder.Entity<Country>().HasData(new {
            Id = "97dcd74c-1d3d-4833-bd22-55a67546d067",
            Name = "United States",
            Code2 = "US",
            Code3 = "USA",
            Location_Latitude = 37.09024,
            Location_Longitude = -95.712891
         });

         builder.Entity<Country>().HasData(new {
            Id = "975e01db-ab12-442c-ba1f-3b424265958d",
            Name = "United States Minor Outlying Islands",
            Code2 = "UM",
            Code3 = "UMI",
            Location_Latitude = 0,
            Location_Longitude = 0
         });

         builder.Entity<Country>().HasData(new {
            Id = "0e66ebff-f321-4e8e-a9b7-0aa4e59a80c2",
            Name = "Uruguay",
            Code2 = "UY",
            Code3 = "URY",
            Location_Latitude = -32.522779,
            Location_Longitude = -55.765835
         });

         builder.Entity<Country>().HasData(new {
            Id = "dc17bfac-fc2d-4f3d-8036-111d9de681f5",
            Name = "Uzbekistan",
            Code2 = "UZ",
            Code3 = "UZB",
            Location_Latitude = 41.377491,
            Location_Longitude = 64.585262
         });

         builder.Entity<Country>().HasData(new {
            Id = "af4e5c94-b79a-431b-a9e8-23688bbeda03",
            Name = "Vanuatu",
            Code2 = "VU",
            Code3 = "VUT",
            Location_Latitude = -15.376706,
            Location_Longitude = 166.959158
         });

         builder.Entity<Country>().HasData(new {
            Id = "31f99f96-c345-4a13-8639-bf716ac9c104",
            Name = "Venezuela (Bolivarian Republic of)",
            Code2 = "VE",
            Code3 = "VEN",
            Location_Latitude = 6.42375,
            Location_Longitude = -66.58973
         });

         builder.Entity<Country>().HasData(new {
            Id = "32aa5036-4cbf-472e-97af-201f143b14bf",
            Name = "Venezuela",
            Code2 = "VE",
            Code3 = "VEN",
            Location_Latitude = 6.42375,
            Location_Longitude = -66.58973
         });

         builder.Entity<Country>().HasData(new {
            Id = "b95674d5-f7de-4238-aba9-5ba8d6b0a742",
            Name = "Viet Nam",
            Code2 = "VN",
            Code3 = "VNM",
            Location_Latitude = 14.058324,
            Location_Longitude = 108.277199
         });

         builder.Entity<Country>().HasData(new {
            Id = "103da448-ca0a-46f9-8c47-aacc7777c552",
            Name = "Virgin Islands (British)",
            Code2 = "VG",
            Code3 = "VGB",
            Location_Latitude = 18.420695,
            Location_Longitude = -64.639968
         });

         builder.Entity<Country>().HasData(new {
            Id = "c30b17c1-5289-49c8-84e2-d3fdd839be1c",
            Name = "Virgin Isles (British)",
            Code2 = "VG",
            Code3 = "VGB",
            Location_Latitude = 18.420695,
            Location_Longitude = -64.639968
         });

         builder.Entity<Country>().HasData(new {
            Id = "44bc7a2e-aeeb-45d3-b6da-b2620e75ac9f",
            Name = "Virgin Islands (U.S.)",
            Code2 = "VI",
            Code3 = "VIR",
            Location_Latitude = 18.335765,
            Location_Longitude = -64.896335
         });

         builder.Entity<Country>().HasData(new {
            Id = "447b16f1-4894-420c-ba88-b8583ccec770",
            Name = "Wallis and Futuna",
            Code2 = "WF",
            Code3 = "WLF",
            Location_Latitude = -13.768752,
            Location_Longitude = -177.156097
         });

         builder.Entity<Country>().HasData(new {
            Id = "7adc80bf-e289-4f2f-88fe-f207d8f9feba",
            Name = "Western Sahara",
            Code2 = "EH",
            Code3 = "ESH",
            Location_Latitude = 24.215527,
            Location_Longitude = -12.885834
         });

         builder.Entity<Country>().HasData(new {
            Id = "2bfa8436-4ad3-4d2f-a4c1-85c990b2e57f",
            Name = "Yemen",
            Code2 = "YE",
            Code3 = "YEM",
            Location_Latitude = 15.552727,
            Location_Longitude = 48.516388
         });

         builder.Entity<Country>().HasData(new {
            Id = "bc262cbe-39da-455f-9249-e421e0038442",
            Name = "Zambia",
            Code2 = "ZM",
            Code3 = "ZMB",
            Location_Latitude = -13.133897,
            Location_Longitude = 27.849332
         });

         builder.Entity<Country>().HasData(new {
            Id = "4fa476dd-5ec0-4169-9f74-a9bc1daf6f49",
            Name = "Zimbabwe",
            Code2 = "ZW",
            Code3 = "ZWE",
            Location_Latitude = -19.015438,
            Location_Longitude = 29.154857
         });
      }
   }
}
