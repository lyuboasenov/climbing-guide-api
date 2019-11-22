using Climbing.Guide.Api.Domain.Entities;
using Climbing.Guide.Api.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Climbing.Guide.Api.Infrastructure.DataSeed {
   public static class ModelBuilderExtensions {
      public static void EnsureSeedData(this ModelBuilder builder) {

         builder.EnsureUsersExist();
         builder.EnsureCountriesExist();
         builder.EnsureAreasExist();
      }

      private static async Task EnsureAreasExist(this ModelBuilder builder) {
         builder.Entity<Area>().HasData(
            new {
               Id = "20144484-65bf-4c55-9f53-3e41cee9d923",
               Name = "Prilep",
               Info = "Prilep info.",
               CountryId = "dfa4af2c-d01d-4a8a-825e-793d49a656ac",
               Location = new Location(41.345351, 21.552799),
               CreatedById = "6401cf99-a0dc-4747-9232-d307b21a360c",
               CreatedOn = DateTime.Now
            });
         builder.Entity<Area>().HasData(
            new {
               Id = "c2fccbf6-4363-4850-ad97-54954812457e",
               ParentId = "20144484-65bf-4c55-9f53-3e41cee9d923",
               AreaContainerId = "20144484-65bf-4c55-9f53-3e41cee9d923",
               Name = "Treskavets",
               Info = "Treskavets Area info.",
               CountryId = "dfa4af2c-d01d-4a8a-825e-793d49a656ac",
               Location = new Location(41.403831, 21.538183),
               CreatedById = "6401cf99-a0dc-4747-9232-d307b21a360c",
               CreatedOn = DateTime.Now
            });
         builder.Entity<Area>().HasData(
            new {
               Id = "8d7d8b36-489b-4d9a-bd73-a7caa9853356",
               Parent = "c2fccbf6-4363-4850-ad97-54954812457e",
               Name = "Paragliding",
               Info = "Paragliding info.",
               CountryId = "dfa4af2c-d01d-4a8a-825e-793d49a656ac",
               Location = new Location(41.397296, 21.532008),
               CreatedById = "6401cf99-a0dc-4747-9232-d307b21a360c",
               CreatedOn = DateTime.Now
            });
         builder.Entity<Area>().HasData(
            new {
               Id = "64875f09-3072-4dab-9d9f-d7286ce818a9",
               ParentId = "20144484-65bf-4c55-9f53-3e41cee9d923",
               AreaContainerId = "20144484-65bf-4c55-9f53-3e41cee9d923",
               Name = "Kamena baba",
               Info = "Kamena baba info.",
               CountryId = "dfa4af2c-d01d-4a8a-825e-793d49a656ac",
               Location = new Location(41.3816981439556, 21.5779556147754),
               CreatedById = "6401cf99-a0dc-4747-9232-d307b21a360c",
               CreatedOn = DateTime.Now
            });
      }

      private static void EnsureUsersExist(this ModelBuilder builder) {
         builder.Entity<User>().HasData(new User() {
            Id = "6401cf99-a0dc-4747-9232-d307b21a360c",
            Name = "superadmin"
         });
      }

      private static void EnsureCountriesExist(this ModelBuilder builder) {
         builder.Entity<Country>().HasData(new Country() {
            Id = "de33eec1-1411-47ce-b20a-d49f8c46d124",
            Name = "Afghanistan",
            Code2 = "AF",
            Code3 = "AFG",
            Location = new Location(33.93911, 67.709953)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "82dee267-33e1-40bf-86db-93f427219f5f",
            Name = "Afghanistan",
            Code2 = "AF",
            Code3 = "AFG",
            Location = new Location(33.93911, 67.709953)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "08f3c3a3-d095-4388-be04-4390a94c487f",
            Name = "Åland Islands",
            Code2 = "AX",
            Code3 = "ALA",
            Location = new Location(0, 0)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "7ed6ca15-0855-45cd-91f4-faaefeecc04a",
            Name = "Albania",
            Code2 = "AL",
            Code3 = "ALB",
            Location = new Location(41.153332, 20.168331)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "de828f97-10fe-41ee-8986-01b7cf20c00e",
            Name = "Algeria",
            Code2 = "DZ",
            Code3 = "DZA",
            Location = new Location(28.033886, 1.659626)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "930c1da1-0df6-431b-81e1-7ded31a2fb67",
            Name = "American Samoa",
            Code2 = "AS",
            Code3 = "ASM",
            Location = new Location(-14.270972, -170.132217)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "4cbf9fbe-febb-4ad8-b82b-5e8a6b230857",
            Name = "Andorra",
            Code2 = "AD",
            Code3 = "AND",
            Location = new Location(42.546245, 1.601554)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "c8659368-4b85-4f08-b207-f0b1606224ed",
            Name = "Angola",
            Code2 = "AO",
            Code3 = "AGO",
            Location = new Location(-11.202692, 17.873887)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "eb92f123-ed9f-4450-9995-75274889e117",
            Name = "Anguilla",
            Code2 = "AI",
            Code3 = "AIA",
            Location = new Location(18.220554, -63.068615)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "ea02e5d0-9e59-4522-b2dc-98765a9d6bdc",
            Name = "Antarctica",
            Code2 = "AQ",
            Code3 = "ATA",
            Location = new Location(-75.250973, -0.071389)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "4d0ef635-6443-4557-b403-5790bc0cec13",
            Name = "Antigua and Barbuda",
            Code2 = "AG",
            Code3 = "ATG",
            Location = new Location(17.060816, -61.796428)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "6d50746b-cea1-481f-93d0-d6bb0917ad6e",
            Name = "Argentina",
            Code2 = "AR",
            Code3 = "ARG",
            Location = new Location(-38.416097, -63.616672)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "8966e710-9740-4c18-971f-cea4ccec679d",
            Name = "Armenia",
            Code2 = "AM",
            Code3 = "ARM",
            Location = new Location(40.069099, 45.038189)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "0888e7a6-9d14-442f-8f05-e0a7b9a706c2",
            Name = "Aruba",
            Code2 = "AW",
            Code3 = "ABW",
            Location = new Location(12.52111, -69.968338)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "16ba0fe8-67f5-419b-869a-a0df3653e1a1",
            Name = "Australia",
            Code2 = "AU",
            Code3 = "AUS",
            Location = new Location(-25.274398, 133.775136)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "fc13267f-8c89-4018-bb7f-54c0f507bcea",
            Name = "Austria",
            Code2 = "AT",
            Code3 = "AUT",
            Location = new Location(47.516231, 14.550072)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "7c9a8e80-f4f6-403f-ab7d-fab7f25f4179",
            Name = "Azerbaijan",
            Code2 = "AZ",
            Code3 = "AZE",
            Location = new Location(40.143105, 47.576927)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "ba85f92e-d2c9-47d5-bf5e-0175dedeb676",
            Name = "Bahamas",
            Code2 = "BS",
            Code3 = "BHS",
            Location = new Location(25.03428, -77.39628)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "92a9bcf7-4140-48dc-8064-25de28c7cfaa",
            Name = "Bahrain",
            Code2 = "BH",
            Code3 = "BHR",
            Location = new Location(25.930414, 50.637772)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "e00f49fe-e9c2-4bbd-9d04-55f5768e6d82",
            Name = "Bangladesh",
            Code2 = "BD",
            Code3 = "BGD",
            Location = new Location(23.684994, 90.356331)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "cf041c61-844b-49dc-8dad-dfd9ea7b6cdc",
            Name = "Barbados",
            Code2 = "BB",
            Code3 = "BRB",
            Location = new Location(13.193887, -59.543198)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "7e5a980a-c6d1-416b-ad42-24c7ed9b7bfe",
            Name = "Belarus",
            Code2 = "BY",
            Code3 = "BLR",
            Location = new Location(53.709807, 27.953389)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "bd05cfff-96cb-43f4-a0b7-6e89568002e3",
            Name = "Belgium",
            Code2 = "BE",
            Code3 = "BEL",
            Location = new Location(50.503887, 4.469936)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "333a74df-70bd-47ae-8fc0-89d6606d971f",
            Name = "Belize",
            Code2 = "BZ",
            Code3 = "BLZ",
            Location = new Location(17.189877, -88.49765)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "26a97c30-c0e2-4981-8f0c-9b42dc5c9388",
            Name = "Benin",
            Code2 = "BJ",
            Code3 = "BEN",
            Location = new Location(9.30769, 2.315834)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "33ddd7c0-b927-4777-9b06-1772ebb26bd3",
            Name = "Bermuda",
            Code2 = "BM",
            Code3 = "BMU",
            Location = new Location(32.321384, -64.75737)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "069b5e09-4629-491d-a384-6c9abfbc04ea",
            Name = "Bhutan",
            Code2 = "BT",
            Code3 = "BTN",
            Location = new Location(27.514162, 90.433601)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "6b9893ca-069d-4c07-bc12-d1865c4a3279",
            Name = "Bolivia (Plurinational State of)",
            Code2 = "BO",
            Code3 = "BOL",
            Location = new Location(-16.290154, -63.588653)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "70ecac8e-0760-44da-8600-a7e8e076a1f7",
            Name = "Bonaire, Sint Eustatius and Saba",
            Code2 = "BQ",
            Code3 = "BES",
            Location = new Location(0, 0)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "dbe227da-b773-4b72-b29b-7979428ee002",
            Name = "Bosnia and Herzegovina",
            Code2 = "BA",
            Code3 = "BIH",
            Location = new Location(43.915886, 17.679076)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "cc661b4c-d1ad-4465-8635-ccb6939f596e",
            Name = "Bosnia & Herzegowina",
            Code2 = "BA",
            Code3 = "BIH",
            Location = new Location(43.915886, 17.679076)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "171637a8-908d-4366-97cf-fd025cd88992",
            Name = "Botswana",
            Code2 = "BW",
            Code3 = "BWA",
            Location = new Location(-22.328474, 24.684866)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "6b98b20b-1560-4391-a2a5-74973a3f0987",
            Name = "Bouvet Island",
            Code2 = "BV",
            Code3 = "BVT",
            Location = new Location(-54.423199, 3.413194)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "4e0166fe-93d8-4550-b546-044d0cce3274",
            Name = "Brazil",
            Code2 = "BR",
            Code3 = "BRA",
            Location = new Location(-14.235004, -51.92528)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "6981ecf9-a720-4478-a1ee-64486089473f",
            Name = "British Indian Ocean Territory",
            Code2 = "IO",
            Code3 = "IOT",
            Location = new Location(-6.343194, 71.876519)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "3fe4cc89-09f7-47f6-a99c-ff3f0f4ea893",
            Name = "Brunei Darussalam",
            Code2 = "BN",
            Code3 = "BRN",
            Location = new Location(4.535277, 114.727669)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "7ebd0fef-d083-4cda-bf33-bb6a43dcbfb4",
            Name = "Bulgaria",
            Code2 = "BG",
            Code3 = "BGR",
            Location = new Location(42.733883, 25.48583)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "41fcadf2-dd29-4631-a7b5-a32e72f69abb",
            Name = "Burkina Faso",
            Code2 = "BF",
            Code3 = "BFA",
            Location = new Location(12.238333, -1.561593)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "b16e59d7-e2bd-45ec-9c98-8cb3d70c7322",
            Name = "Burundi",
            Code2 = "BI",
            Code3 = "BDI",
            Location = new Location(-3.373056, 29.918886)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "de3de723-792c-46b8-b204-08d45ebf1016",
            Name = "Cabo Verde",
            Code2 = "CV",
            Code3 = "CPV",
            Location = new Location(16.002082, -24.013197)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "7e1cc181-2328-449b-adfb-bfeeff221796",
            Name = "Cambodia",
            Code2 = "KH",
            Code3 = "KHM",
            Location = new Location(12.565679, 104.990963)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "8a5a244d-8dce-462d-9f74-940bf61c2c07",
            Name = "Cameroon",
            Code2 = "CM",
            Code3 = "CMR",
            Location = new Location(7.369722, 12.354722)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "7df7a355-dc78-4694-a211-0d08b7f316bd",
            Name = "Canada",
            Code2 = "CA",
            Code3 = "CAN",
            Location = new Location(56.130366, -106.346771)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "1b4d5763-23fa-4400-b256-504527cbd401",
            Name = "Cayman Islands",
            Code2 = "KY",
            Code3 = "CYM",
            Location = new Location(19.513469, -80.566956)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "4744737d-32df-41a1-9531-1fe376c60711",
            Name = "Central African Republic",
            Code2 = "CF",
            Code3 = "CAF",
            Location = new Location(6.611111, 20.939444)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "a849e78c-9ee9-4bac-8aa8-bc7cf4faf28f",
            Name = "Chad",
            Code2 = "TD",
            Code3 = "TCD",
            Location = new Location(15.454166, 18.732207)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "785b66bb-ea3c-4c64-98ed-43fa2d9a721e",
            Name = "Chile",
            Code2 = "CL",
            Code3 = "CHL",
            Location = new Location(-35.675147, -71.542969)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "b5d4756a-6ae4-4f19-aa26-54eaa67fdf69",
            Name = "China",
            Code2 = "CN",
            Code3 = "CHN",
            Location = new Location(35.86166, 104.195397)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "1b174072-549c-4493-b454-9dccf4a2def8",
            Name = "Christmas Island",
            Code2 = "CX",
            Code3 = "CXR",
            Location = new Location(-10.447525, 105.690449)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "2b0fe3f6-2396-4639-85ea-353b70ead6c6",
            Name = "Cocos (Keeling) Islands",
            Code2 = "CC",
            Code3 = "CCK",
            Location = new Location(-12.164165, 96.870956)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "8423aa88-8617-44b3-95d5-67848142d4c0",
            Name = "Colombia",
            Code2 = "CO",
            Code3 = "COL",
            Location = new Location(4.570868, -74.297333)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "2e3c462c-950b-4095-9593-5b3226fe4351",
            Name = "Comoros",
            Code2 = "KM",
            Code3 = "COM",
            Location = new Location(-11.875001, 43.872219)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "86050428-13a9-48e6-b7eb-38dd38aecc6f",
            Name = "Congo",
            Code2 = "CG",
            Code3 = "COG",
            Location = new Location(-0.228021, 15.827659)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "4f26a7bb-41f3-4c68-851f-de2829a36992",
            Name = "Congo (Democratic Republic of the)",
            Code2 = "CD",
            Code3 = "COD",
            Location = new Location(-4.038333, 21.758664)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "a4ea04d5-6ae6-485a-b05d-cd4540983f7b",
            Name = "Cook Islands",
            Code2 = "CK",
            Code3 = "COK",
            Location = new Location(-21.236736, -159.777671)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "553dc614-e822-4758-8d91-421e4877f002",
            Name = "Costa Rica",
            Code2 = "CR",
            Code3 = "CRI",
            Location = new Location(9.748917, -83.753428)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "14cf4ef8-838b-4c47-b7d1-c0eeef30e8f8",
            Name = "Côte d'Ivoire",
            Code2 = "CI",
            Code3 = "CIV",
            Location = new Location(7.539989, -5.54708)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "5d179411-56f1-44d9-b247-31c004b6423e",
            Name = "Croatia",
            Code2 = "HR",
            Code3 = "HRV",
            Location = new Location(45.1, 15.2)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "0f262c79-4b51-43cd-b443-cde7de17c592",
            Name = "Cuba",
            Code2 = "CU",
            Code3 = "CUB",
            Location = new Location(21.521757, -77.781167)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "4fd3f15e-066d-4241-8581-a6d57996ba9c",
            Name = "Curaçao",
            Code2 = "CW",
            Code3 = "CUW",
            Location = new Location(0, 0)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "1153378f-1987-42d2-af19-66b0cebf3ba8",
            Name = "Cyprus",
            Code2 = "CY",
            Code3 = "CYP",
            Location = new Location(35.126413, 33.429859)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "b0842743-128c-4ba1-9311-7a540dae79c4",
            Name = "Czechia",
            Code2 = "CZ",
            Code3 = "CZE",
            Location = new Location(49.817492, 15.472962)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "0a2d8878-c25c-4a8d-8549-dc5c3846846f",
            Name = "Czech Republic",
            Code2 = "CZ",
            Code3 = "CZE",
            Location = new Location(49.817492, 15.472962)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "2846b4cd-c3fa-4d92-963e-011acd03cf90",
            Name = "Denmark",
            Code2 = "DK",
            Code3 = "DNK",
            Location = new Location(56.26392, 9.501785)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "e0f4f614-352a-441c-920c-b56f5094fd22",
            Name = "Djibouti",
            Code2 = "DJ",
            Code3 = "DJI",
            Location = new Location(11.825138, 42.590275)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "cb2a5362-d2b3-4fcd-9dc6-c449aae6102d",
            Name = "Dominica",
            Code2 = "DM",
            Code3 = "DMA",
            Location = new Location(15.414999, -61.370976)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "1ab814d4-ca7c-4057-aa89-79815ceac161",
            Name = "Dominican Republic",
            Code2 = "DO",
            Code3 = "DOM",
            Location = new Location(18.735693, -70.162651)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "09a8d8ec-8963-4f38-8a83-bb71c45f8a91",
            Name = "Ecuador",
            Code2 = "EC",
            Code3 = "ECU",
            Location = new Location(-1.831239, -78.183406)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "d7ba78d6-20f4-4d78-997a-805864216d23",
            Name = "Egypt",
            Code2 = "EG",
            Code3 = "EGY",
            Location = new Location(26.820553, 30.802498)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "756f3762-12d5-478d-a20d-1471f8301641",
            Name = "El Salvador",
            Code2 = "SV",
            Code3 = "SLV",
            Location = new Location(13.794185, -88.89653)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "c88e9be6-79fc-4109-bb94-3230ce66e131",
            Name = "Equatorial Guinea",
            Code2 = "GQ",
            Code3 = "GNQ",
            Location = new Location(1.650801, 10.267895)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "bfbada67-1d09-41b1-91bf-949e575be864",
            Name = "Eritrea",
            Code2 = "ER",
            Code3 = "ERI",
            Location = new Location(15.179384, 39.782334)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "515c3677-9879-4c68-92a0-fae579fdcca9",
            Name = "Estonia",
            Code2 = "EE",
            Code3 = "EST",
            Location = new Location(58.595272, 25.013607)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "ae58d193-2c6d-4434-9a57-cdc882e93416",
            Name = "Eswatini",
            Code2 = "SZ",
            Code3 = "SWZ",
            Location = new Location(-26.522503, 31.465866)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "3bc7e09a-c80f-41dd-b48b-11496b3ff7a4",
            Name = "Ethiopia",
            Code2 = "ET",
            Code3 = "ETH",
            Location = new Location(9.145, 40.489673)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "c6f8699a-cfbf-4523-abb3-181c3192d090",
            Name = "Falkland Islands (Malvinas)",
            Code2 = "FK",
            Code3 = "FLK",
            Location = new Location(-51.796253, -59.523613)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "89ca895d-039d-44f3-aa5f-3d40d1e6aa60",
            Name = "Faroe Islands",
            Code2 = "FO",
            Code3 = "FRO",
            Location = new Location(61.892635, -6.911806)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "1cce73ac-4b1b-4ba6-8475-a8d2d202e3c4",
            Name = "Fiji",
            Code2 = "FJ",
            Code3 = "FJI",
            Location = new Location(-16.578193, 179.414413)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "03397ef7-954f-47b0-b5d8-d68c1966f668",
            Name = "Finland",
            Code2 = "FI",
            Code3 = "FIN",
            Location = new Location(61.92411, 25.748151)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "8b5717bd-86a9-48ab-ba91-35966fa846c5",
            Name = "France",
            Code2 = "FR",
            Code3 = "FRA",
            Location = new Location(46.227638, 2.213749)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "0c329a3c-978c-4c10-8bb2-b1ac6a040333",
            Name = "French Guiana",
            Code2 = "GF",
            Code3 = "GUF",
            Location = new Location(3.933889, -53.125782)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "af8422b2-04ae-4256-a0e5-95e83598efd8",
            Name = "French Polynesia",
            Code2 = "PF",
            Code3 = "PYF",
            Location = new Location(-17.679742, -149.406843)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "3e2cab1a-292e-4572-b5cc-16f84d1bd8f5",
            Name = "French Southern Territories",
            Code2 = "TF",
            Code3 = "ATF",
            Location = new Location(-49.280366, 69.348557)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "ecb53185-b48a-4783-9ba8-75bd434b3b96",
            Name = "Gabon",
            Code2 = "GA",
            Code3 = "GAB",
            Location = new Location(-0.803689, 11.609444)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "e1a99054-abac-4c5c-ade2-540ab7eec571",
            Name = "Gambia",
            Code2 = "GM",
            Code3 = "GMB",
            Location = new Location(13.443182, -15.310139)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "8a231184-53ea-491f-9ea3-fb821406c732",
            Name = "Georgia",
            Code2 = "GE",
            Code3 = "GEO",
            Location = new Location(42.315407, 43.356892)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "afa95357-74da-4e58-9f7c-1b2147701ce9",
            Name = "Germany",
            Code2 = "DE",
            Code3 = "DEU",
            Location = new Location(51.165691, 10.451526)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "cc17996a-a90c-4dc5-9a81-efdf0e055884",
            Name = "Ghana",
            Code2 = "GH",
            Code3 = "GHA",
            Location = new Location(7.946527, -1.023194)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "4705f573-4add-49dc-a621-b5665010df96",
            Name = "Gibraltar",
            Code2 = "GI",
            Code3 = "GIB",
            Location = new Location(36.137741, -5.345374)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "a1e96706-9dce-4362-be37-bb93042b1848",
            Name = "Greece",
            Code2 = "GR",
            Code3 = "GRC",
            Location = new Location(39.074208, 21.824312)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "d2c0fc10-6381-4d50-a328-0d6320af3f6b",
            Name = "Greenland",
            Code2 = "GL",
            Code3 = "GRL",
            Location = new Location(71.706936, -42.604303)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "a96ec412-2ff5-489d-ae08-9ec7b283e17c",
            Name = "Grenada",
            Code2 = "GD",
            Code3 = "GRD",
            Location = new Location(12.262776, -61.604171)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "ec54217b-72ae-4d36-9b47-faac2b0650bd",
            Name = "Guadeloupe",
            Code2 = "GP",
            Code3 = "GLP",
            Location = new Location(16.995971, -62.067641)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "10757450-3e84-40f0-8600-856d02cae8c4",
            Name = "Guam",
            Code2 = "GU",
            Code3 = "GUM",
            Location = new Location(13.444304, 144.793731)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "e793e178-5c1c-4c6c-bf1f-204b6325f166",
            Name = "Guatemala",
            Code2 = "GT",
            Code3 = "GTM",
            Location = new Location(15.783471, -90.230759)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "e802c8a1-a6f5-4787-b4ac-704f0b5fbe69",
            Name = "Guernsey",
            Code2 = "GG",
            Code3 = "GGY",
            Location = new Location(49.465691, -2.585278)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "b1f80812-12cb-4911-86fa-868ec64af1d6",
            Name = "Guinea",
            Code2 = "GN",
            Code3 = "GIN",
            Location = new Location(9.945587, -9.696645)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "e6fe5ddd-e6fb-4405-a04c-c2c45aa7681c",
            Name = "Guinea-Bissau",
            Code2 = "GW",
            Code3 = "GNB",
            Location = new Location(11.803749, -15.180413)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "a4ecda16-e2a2-4f92-9a2f-0adafd249a87",
            Name = "Guyana",
            Code2 = "GY",
            Code3 = "GUY",
            Location = new Location(4.860416, -58.93018)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "ba10f2f9-fd6a-4a52-838e-d86e9e6231bc",
            Name = "Haiti",
            Code2 = "HT",
            Code3 = "HTI",
            Location = new Location(18.971187, -72.285215)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "fe827e3f-e140-40ad-a384-3268d401b3b3",
            Name = "Heard Island and McDonald Islands",
            Code2 = "HM",
            Code3 = "HMD",
            Location = new Location(-53.08181, 73.504158)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "20c4a11a-8a42-4f26-9e12-c79909089f65",
            Name = "Holy See",
            Code2 = "VA",
            Code3 = "VAT",
            Location = new Location(41.902916, 12.453389)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "e5623ac1-faff-4395-abd7-ee749a32f1f2",
            Name = "Honduras",
            Code2 = "HN",
            Code3 = "HND",
            Location = new Location(15.199999, -86.241905)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "88da3df2-ab53-4c5b-a92a-f3ec7b69e837",
            Name = "Hong Kong",
            Code2 = "HK",
            Code3 = "HKG",
            Location = new Location(22.396428, 114.109497)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "52bbc191-e333-4cf1-bf06-bfcd5c501b96",
            Name = "Hungary",
            Code2 = "HU",
            Code3 = "HUN",
            Location = new Location(47.162494, 19.503304)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "76130778-8596-4474-b57a-842d1deedf25",
            Name = "Iceland",
            Code2 = "IS",
            Code3 = "ISL",
            Location = new Location(64.963051, -19.020835)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "b7bd5cca-bc0d-4976-bf36-43b9331e663b",
            Name = "India",
            Code2 = "IN",
            Code3 = "IND",
            Location = new Location(20.593684, 78.96288)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "aa5f5431-a25b-4a9b-9e62-b8257602aa4d",
            Name = "Indonesia",
            Code2 = "ID",
            Code3 = "IDN",
            Location = new Location(-0.789275, 113.921327)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "da2dfbff-aa9e-4e32-9dd9-a9ee6c2c15e7",
            Name = "Iran (Islamic Republic of)",
            Code2 = "IR",
            Code3 = "IRN",
            Location = new Location(32.427908, 53.688046)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "47f432bc-a53d-4fb0-9ece-c0ae5a46581f",
            Name = "Iran",
            Code2 = "IR",
            Code3 = "IRN",
            Location = new Location(32.427908, 53.688046)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "1c6a0760-f7b7-4a72-b537-935c14fab655",
            Name = "Iraq",
            Code2 = "IQ",
            Code3 = "IRQ",
            Location = new Location(33.223191, 43.679291)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "aa2fa28e-b2b6-4944-828f-d5322ece526e",
            Name = "Ireland",
            Code2 = "IE",
            Code3 = "IRL",
            Location = new Location(53.41291, -8.24389)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "153dd65e-0091-4f61-898f-cd9d5adbb7aa",
            Name = "Isle of Man",
            Code2 = "IM",
            Code3 = "IMN",
            Location = new Location(54.236107, -4.548056)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "e71d7fec-7f8c-4bea-a269-f0da1f3d843a",
            Name = "Israel",
            Code2 = "IL",
            Code3 = "ISR",
            Location = new Location(31.046051, 34.851612)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "a73f294d-2e47-4e25-a451-73d98e96dc4b",
            Name = "Italy",
            Code2 = "IT",
            Code3 = "ITA",
            Location = new Location(41.87194, 12.56738)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "e019f94b-5280-4a4a-9243-4068dafc96d8",
            Name = "Jamaica",
            Code2 = "JM",
            Code3 = "JAM",
            Location = new Location(18.109581, -77.297508)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "a4df9386-e9a9-4951-8c4c-587f3fe00b7f",
            Name = "Japan",
            Code2 = "JP",
            Code3 = "JPN",
            Location = new Location(36.204824, 138.252924)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "d21a65de-89b8-4704-ae49-e15aeeb19c6f",
            Name = "Jersey",
            Code2 = "JE",
            Code3 = "JEY",
            Location = new Location(49.214439, -2.13125)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "7ee6e5ea-aacd-47b5-85f7-c84ad7d89941",
            Name = "Jordan",
            Code2 = "JO",
            Code3 = "JOR",
            Location = new Location(30.585164, 36.238414)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "15a639d1-dfda-4a66-910d-eaf42d6d8287",
            Name = "Kazakhstan",
            Code2 = "KZ",
            Code3 = "KAZ",
            Location = new Location(48.019573, 66.923684)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "219aeb9b-281d-4081-b654-8ec891aa9414",
            Name = "Kenya",
            Code2 = "KE",
            Code3 = "KEN",
            Location = new Location(-0.023559, 37.906193)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "0be5ae0a-4c73-4e52-880a-70fef2cbbb94",
            Name = "Kiribati",
            Code2 = "KI",
            Code3 = "KIR",
            Location = new Location(-3.370417, -168.734039)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "e601f9f3-5095-41c4-ae56-35022239f519",
            Name = "Korea (Democratic People's Republic of)",
            Code2 = "KP",
            Code3 = "PRK",
            Location = new Location(40.339852, 127.510093)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "5af9042a-ad8c-4a6b-a33e-407cf8d53450",
            Name = "Korea (Republic of)",
            Code2 = "KR",
            Code3 = "KOR",
            Location = new Location(35.907757, 127.766922)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "c1776118-4af0-4301-91a3-dc8de41a105e",
            Name = "Korea",
            Code2 = "KR",
            Code3 = "KOR",
            Location = new Location(35.907757, 127.766922)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "74dd862d-3da1-44a3-b8e9-a605ed012b40",
            Name = "Kuwait",
            Code2 = "KW",
            Code3 = "KWT",
            Location = new Location(29.31166, 47.481766)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "9678fd97-738a-4269-9a7b-75a7cd8e7c5e",
            Name = "Kyrgyzstan",
            Code2 = "KG",
            Code3 = "KGZ",
            Location = new Location(41.20438, 74.766098)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "90d8916f-08c9-41d3-9a47-3ea339a5d446",
            Name = "Lao People's Democratic Republic",
            Code2 = "LA",
            Code3 = "LAO",
            Location = new Location(19.85627, 102.495496)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "aabd73da-df61-49a7-b933-e714f885041b",
            Name = "Laos",
            Code2 = "LA",
            Code3 = "LAO",
            Location = new Location(19.85627, 102.495496)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "273f2436-af2d-4e4e-a62c-52e901dd1ece",
            Name = "Latvia",
            Code2 = "LV",
            Code3 = "LVA",
            Location = new Location(56.879635, 24.603189)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "a6ac7561-fa32-40c4-b15c-380a39ab2353",
            Name = "Lebanon",
            Code2 = "LB",
            Code3 = "LBN",
            Location = new Location(33.854721, 35.862285)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "f1fc4106-e5eb-4301-96cd-4b7527a6182e",
            Name = "Lesotho",
            Code2 = "LS",
            Code3 = "LSO",
            Location = new Location(-29.609988, 28.233608)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "106f921b-c0d5-4c04-a5b3-25c6b9136208",
            Name = "Liberia",
            Code2 = "LR",
            Code3 = "LBR",
            Location = new Location(6.428055, -9.429499)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "58079524-324a-436a-9f47-a5e6fc5e416b",
            Name = "Libya",
            Code2 = "LY",
            Code3 = "LBY",
            Location = new Location(26.3351, 17.228331)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "15839de6-2d52-431d-bdac-e5643263e1c1",
            Name = "Liechtenstein",
            Code2 = "LI",
            Code3 = "LIE",
            Location = new Location(47.166, 9.555373)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "3e49f1f0-a3e6-43d6-ab6a-24a73b58739c",
            Name = "Lithuania",
            Code2 = "LT",
            Code3 = "LTU",
            Location = new Location(55.169438, 23.881275)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "ea399840-15bf-4e89-ba02-80d8f942d892",
            Name = "Luxembourg",
            Code2 = "LU",
            Code3 = "LUX",
            Location = new Location(49.815273, 6.129583)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "1b78b82c-98ae-4e68-8d0d-67c54bec43fa",
            Name = "Macao",
            Code2 = "MO",
            Code3 = "MAC",
            Location = new Location(22.198745, 113.543873)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "d5c636d1-7d42-4890-a54b-7df4fb34c8a7",
            Name = "Macedonia (the former Yugoslav Republic of)",
            Code2 = "MK",
            Code3 = "MKD",
            Location = new Location(41.608635, 21.745275)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "7475913e-c455-4a6e-a88a-4efbcacc3757",
            Name = "Macedonia",
            Code2 = "MK",
            Code3 = "MKD",
            Location = new Location(41.608635, 21.745275)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "6d3ba0f6-4bf4-4617-834d-5c3ad640ae8f",
            Name = "Madagascar",
            Code2 = "MG",
            Code3 = "MDG",
            Location = new Location(-18.766947, 46.869107)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "71e6e58b-5708-4eaf-b457-7ac8850cd6bc",
            Name = "Malawi",
            Code2 = "MW",
            Code3 = "MWI",
            Location = new Location(-13.254308, 34.301525)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "976fb79f-c7ec-4fc3-9122-6d924a1bc6b6",
            Name = "Malaysia",
            Code2 = "MY",
            Code3 = "MYS",
            Location = new Location(4.210484, 101.975766)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "6e5889ea-ea3b-47fd-97ea-3c55217e13d8",
            Name = "Maldives",
            Code2 = "MV",
            Code3 = "MDV",
            Location = new Location(3.202778, 73.22068)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "b272323f-7d69-4c3f-80d9-13fe0ca77e9f",
            Name = "Mali",
            Code2 = "ML",
            Code3 = "MLI",
            Location = new Location(17.570692, -3.996166)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "3fdb1c8e-e3d7-4162-a166-bf5bf376f965",
            Name = "Malta",
            Code2 = "MT",
            Code3 = "MLT",
            Location = new Location(35.937496, 14.375416)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "a1d67e5e-2c9e-4d7e-9e29-456cc171f541",
            Name = "Marshall Islands",
            Code2 = "MH",
            Code3 = "MHL",
            Location = new Location(7.131474, 171.184478)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "d5563b04-bd6c-4753-a281-14eaf5764f55",
            Name = "Martinique",
            Code2 = "MQ",
            Code3 = "MTQ",
            Location = new Location(14.641528, -61.024174)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "23fa4c96-810c-4c29-af3f-935d1ad1890d",
            Name = "Mauritania",
            Code2 = "MR",
            Code3 = "MRT",
            Location = new Location(21.00789, -10.940835)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "89f91bbe-15b0-4165-bec6-757582fed112",
            Name = "Mauritius",
            Code2 = "MU",
            Code3 = "MUS",
            Location = new Location(-20.348404, 57.552152)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "02363cce-8e2b-4eef-829c-8ed901fe1ec5",
            Name = "Mayotte",
            Code2 = "YT",
            Code3 = "MYT",
            Location = new Location(-12.8275, 45.166244)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "f92b0510-a84c-4e95-a7ee-0b3ca1254542",
            Name = "Mexico",
            Code2 = "MX",
            Code3 = "MEX",
            Location = new Location(23.634501, -102.552784)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "e51aad30-0271-447d-8fb4-608924ebaa46",
            Name = "Micronesia (Federated States of)",
            Code2 = "FM",
            Code3 = "FSM",
            Location = new Location(7.425554, 150.550812)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "573ccf92-b136-47cf-924c-9338babaea09",
            Name = "Moldova (Republic of)",
            Code2 = "MD",
            Code3 = "MDA",
            Location = new Location(47.411631, 28.369885)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "1ab46d63-e881-41d9-8c3e-40df8969c2c6",
            Name = "Monaco",
            Code2 = "MC",
            Code3 = "MCO",
            Location = new Location(43.750298, 7.412841)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "48d403be-a39b-4172-9310-dc0a94dcb8b4",
            Name = "Mongolia",
            Code2 = "MN",
            Code3 = "MNG",
            Location = new Location(46.862496, 103.846656)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "85955518-113c-49aa-9a12-5394adbc9cbf",
            Name = "Montenegro",
            Code2 = "ME",
            Code3 = "MNE",
            Location = new Location(42.708678, 19.37439)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "8cfc6202-5ebf-4708-b45a-3566e224f3fb",
            Name = "Montserrat",
            Code2 = "MS",
            Code3 = "MSR",
            Location = new Location(16.742498, -62.187366)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "0ac8777f-c7d7-4292-9b6c-b2b7fec6774f",
            Name = "Morocco",
            Code2 = "MA",
            Code3 = "MAR",
            Location = new Location(31.791702, -7.09262)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "13dfb95f-f447-4193-ac7b-a5734f203687",
            Name = "Mozambique",
            Code2 = "MZ",
            Code3 = "MOZ",
            Location = new Location(-18.665695, 35.529562)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "68a9771f-d0ab-40e1-8e38-97d7d3ec0fed",
            Name = "Myanmar",
            Code2 = "MM",
            Code3 = "MMR",
            Location = new Location(21.913965, 95.956223)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "b336bf68-4345-4d40-a63c-c55a6db61ea8",
            Name = "Namibia",
            Code2 = "NA",
            Code3 = "NAM",
            Location = new Location(-22.95764, 18.49041)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "67337722-ad53-4832-b932-f10ebf516580",
            Name = "Nauru",
            Code2 = "NR",
            Code3 = "NRU",
            Location = new Location(-0.522778, 166.931503)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "5f5557f5-f5a3-4a7e-8eb2-c35158328104",
            Name = "Nepal",
            Code2 = "NP",
            Code3 = "NPL",
            Location = new Location(28.394857, 84.124008)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "edc4f5b9-ccdb-438f-a17a-6c16d0f5e7cb",
            Name = "Netherlands",
            Code2 = "NL",
            Code3 = "NLD",
            Location = new Location(52.132633, 5.291266)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "519d3bb9-4789-4a86-a515-9619b1909858",
            Name = "New Caledonia",
            Code2 = "NC",
            Code3 = "NCL",
            Location = new Location(-20.904305, 165.618042)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "898691f3-407c-4391-91f8-907fef4e5fb8",
            Name = "New Zealand",
            Code2 = "NZ",
            Code3 = "NZL",
            Location = new Location(-40.900557, 174.885971)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "b8078a07-dba8-4f85-b1c0-825b7b4d53be",
            Name = "Nicaragua",
            Code2 = "NI",
            Code3 = "NIC",
            Location = new Location(12.865416, -85.207229)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "2ff5cc22-d63d-45d4-9f5f-ee1a96fad688",
            Name = "Niger",
            Code2 = "NE",
            Code3 = "NER",
            Location = new Location(17.607789, 8.081666)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "0de0c1bc-29e0-4706-a621-d2b033f944aa",
            Name = "Nigeria",
            Code2 = "NG",
            Code3 = "NGA",
            Location = new Location(9.081999, 8.675277)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "cb5fcf91-b002-41e4-aa3e-6fd34e8892a2",
            Name = "Niue",
            Code2 = "NU",
            Code3 = "NIU",
            Location = new Location(-19.054445, -169.867233)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "f8fff66d-848a-40a3-bce4-bcc38e509d75",
            Name = "Norfolk Island",
            Code2 = "NF",
            Code3 = "NFK",
            Location = new Location(-29.040835, 167.954712)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "838df85e-4289-431a-a771-c73d1e20f879",
            Name = "Northern Mariana Islands",
            Code2 = "MP",
            Code3 = "MNP",
            Location = new Location(17.33083, 145.38469)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "67dbd234-311b-49cf-b958-81e33dd6a6b0",
            Name = "Norway",
            Code2 = "NO",
            Code3 = "NOR",
            Location = new Location(60.472024, 8.468946)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "da09ace0-116e-4ecb-a5de-ccf16bcdc55f",
            Name = "Oman",
            Code2 = "OM",
            Code3 = "OMN",
            Location = new Location(21.512583, 55.923255)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "080f2236-f56a-4a79-8d3a-4fb47c1c5ae8",
            Name = "Pakistan",
            Code2 = "PK",
            Code3 = "PAK",
            Location = new Location(30.375321, 69.345116)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "37e81590-4fe2-439f-8ae7-722754c8ae36",
            Name = "Palau",
            Code2 = "PW",
            Code3 = "PLW",
            Location = new Location(7.51498, 134.58252)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "02126894-7607-4f96-a7de-ef70fd803b32",
            Name = "Palestine, State of",
            Code2 = "PS",
            Code3 = "PSE",
            Location = new Location(31.952162, 35.233154)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "170c3185-56a4-45cf-9a02-155170f08d88",
            Name = "Panama",
            Code2 = "PA",
            Code3 = "PAN",
            Location = new Location(8.537981, -80.782127)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "2569c7db-1643-4a7b-be71-58728a279f50",
            Name = "Papua New Guinea",
            Code2 = "PG",
            Code3 = "PNG",
            Location = new Location(-6.314993, 143.95555)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "720976cf-eb1e-4154-95e6-8a65dc594d6b",
            Name = "Paraguay",
            Code2 = "PY",
            Code3 = "PRY",
            Location = new Location(-23.442503, -58.443832)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "a50a83ef-996d-40fc-bb42-f83bd803318f",
            Name = "Peru",
            Code2 = "PE",
            Code3 = "PER",
            Location = new Location(-9.189967, -75.015152)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "9439669c-4a25-4bdd-81f4-d8fab7550c59",
            Name = "Philippines",
            Code2 = "PH",
            Code3 = "PHL",
            Location = new Location(12.879721, 121.774017)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "3dc9dcbf-feb3-4b35-a5cb-985eb95f2727",
            Name = "Pitcairn",
            Code2 = "PN",
            Code3 = "PCN",
            Location = new Location(-24.703615, -127.439308)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "6036195b-06c0-4be2-8c2d-06bb8b8490af",
            Name = "Poland",
            Code2 = "PL",
            Code3 = "POL",
            Location = new Location(51.919438, 19.145136)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "22b62f65-e5ff-44a3-9ee9-5968a128968b",
            Name = "Portugal",
            Code2 = "PT",
            Code3 = "PRT",
            Location = new Location(39.399872, -8.224454)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "b5a3ecdb-af19-4343-ae05-c2e75cd199d7",
            Name = "Puerto Rico",
            Code2 = "PR",
            Code3 = "PRI",
            Location = new Location(18.220833, -66.590149)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "1b948673-7b9f-4748-9a4e-84bc5ae37b05",
            Name = "Qatar",
            Code2 = "QA",
            Code3 = "QAT",
            Location = new Location(25.354826, 51.183884)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "95722eab-9002-4653-b906-19e610370edb",
            Name = "Réunion",
            Code2 = "RE",
            Code3 = "REU",
            Location = new Location(-21.115141, 55.536384)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "00525050-fea4-4fea-b163-f39b64abf66b",
            Name = "Reunion",
            Code2 = "RE",
            Code3 = "REU",
            Location = new Location(-21.115141, 55.536384)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "efcc61d5-d644-4811-9e4b-66188dfbda9c",
            Name = "Romania",
            Code2 = "RO",
            Code3 = "ROU",
            Location = new Location(45.943161, 24.96676)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "041a7f28-b4d1-4b50-b910-2f3718461d2d",
            Name = "Russian Federation",
            Code2 = "RU",
            Code3 = "RUS",
            Location = new Location(61.52401, 105.318756)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "e2afb616-81e2-4318-b75a-4d96a829410b",
            Name = "Russia",
            Code2 = "RU",
            Code3 = "RUS",
            Location = new Location(61.52401, 105.318756)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "d5aa861a-626f-4706-b348-c5993fe07096",
            Name = "Rwanda",
            Code2 = "RW",
            Code3 = "RWA",
            Location = new Location(-1.940278, 29.873888)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "5fa95821-5fa2-4344-b40d-a82c5ee9d2fd",
            Name = "Saint Barthélemy",
            Code2 = "BL",
            Code3 = "BLM",
            Location = new Location(0, 0)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "8c31be1d-2319-40e9-b40d-a43ae7c69649",
            Name = "Saint Helena, Ascension and Tristan da Cunha",
            Code2 = "SH",
            Code3 = "SHN",
            Location = new Location(-24.143474, -10.030696)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "5376dc84-1dcd-4c4e-b989-d82124614492",
            Name = "Saint Kitts and Nevis",
            Code2 = "KN",
            Code3 = "KNA",
            Location = new Location(17.357822, -62.782998)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "fa9aa6ba-9b0d-48f6-aa82-0418fb2380fd",
            Name = "Saint Lucia",
            Code2 = "LC",
            Code3 = "LCA",
            Location = new Location(13.909444, -60.978893)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "de5c872e-becd-4bf6-9a74-eed385ac8165",
            Name = "Saint Martin (French part)",
            Code2 = "MF",
            Code3 = "MAF",
            Location = new Location(0, 0)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "325f24bf-e067-46ac-8af9-c4591621cbc2",
            Name = "Saint Pierre and Miquelon",
            Code2 = "PM",
            Code3 = "SPM",
            Location = new Location(46.941936, -56.27111)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "5e076736-2877-4b63-802e-5a8581b4fe23",
            Name = "Saint Vincent and the Grenadines",
            Code2 = "VC",
            Code3 = "VCT",
            Location = new Location(12.984305, -61.287228)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "a969d68d-d8f4-4948-a120-39824ccbd657",
            Name = "Samoa",
            Code2 = "WS",
            Code3 = "WSM",
            Location = new Location(-13.759029, -172.104629)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "a270de44-ae42-48ec-b955-c58737af7981",
            Name = "San Marino",
            Code2 = "SM",
            Code3 = "SMR",
            Location = new Location(43.94236, 12.457777)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "222b8b6a-8848-4d89-b008-4b4eed74c6e5",
            Name = "Sao Tome and Principe",
            Code2 = "ST",
            Code3 = "STP",
            Location = new Location(0.18636, 6.613081)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "64e63e60-0bd7-4463-893e-f0c38d97691a",
            Name = "Saudi Arabia",
            Code2 = "SA",
            Code3 = "SAU",
            Location = new Location(23.885942, 45.079162)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "4268d70b-c383-49e0-94e5-8e7620ce5dd7",
            Name = "Senegal",
            Code2 = "SN",
            Code3 = "SEN",
            Location = new Location(14.497401, -14.452362)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "8094745f-565b-48b8-9b85-aea028634a30",
            Name = "Serbia",
            Code2 = "RS",
            Code3 = "SRB",
            Location = new Location(44.016521, 21.005859)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "3e4536f4-8188-4ec4-a1bc-9f93dbd3f332",
            Name = "Serbia (Yugoslavia)",
            Code2 = "RS",
            Code3 = "SRB",
            Location = new Location(44.016521, 21.005859)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "758f8d77-0042-4217-b54d-64ed0d3f389b",
            Name = "Seychelles",
            Code2 = "SC",
            Code3 = "SYC",
            Location = new Location(-4.679574, 55.491977)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "e2793017-8983-41e9-82d0-cc402ba67821",
            Name = "Sierra Leone",
            Code2 = "SL",
            Code3 = "SLE",
            Location = new Location(8.460555, -11.779889)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "cd6b5cee-52cd-4faa-8f79-517c496d1905",
            Name = "Singapore",
            Code2 = "SG",
            Code3 = "SGP",
            Location = new Location(1.352083, 103.819836)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "f0d3caf3-5559-4ca4-a08c-48d597844cb5",
            Name = "Sint Maarten (Dutch part)",
            Code2 = "SX",
            Code3 = "SXM",
            Location = new Location(0, 0)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "cdb13add-f9dd-46f3-9eba-74b888e9bf5c",
            Name = "Slovakia",
            Code2 = "SK",
            Code3 = "SVK",
            Location = new Location(48.669026, 19.699024)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "f8036f60-ed43-4df3-882b-1f9ad62d15e9",
            Name = "Slovenia",
            Code2 = "SI",
            Code3 = "SVN",
            Location = new Location(46.151241, 14.995463)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "6b0ce29c-58e0-46a9-97e7-95eab0dc7042",
            Name = "Solomon Islands",
            Code2 = "SB",
            Code3 = "SLB",
            Location = new Location(-9.64571, 160.156194)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "dd31adfe-4585-470f-ac52-b76da3776759",
            Name = "Somalia",
            Code2 = "SO",
            Code3 = "SOM",
            Location = new Location(5.152149, 46.199616)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "5da81b83-04bd-4191-90c1-638f29859223",
            Name = "South Africa",
            Code2 = "ZA",
            Code3 = "ZAF",
            Location = new Location(-30.559482, 22.937506)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "c506e31f-e2a0-47fb-815e-2111a437e5d6",
            Name = "South Georgia and the South Sandwich Islands",
            Code2 = "GS",
            Code3 = "SGS",
            Location = new Location(-54.429579, -36.587909)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "e62f05e2-c7c8-43de-818b-6b3a4e9dcbdd",
            Name = "South Sudan",
            Code2 = "SS",
            Code3 = "SSD",
            Location = new Location(0, 0)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "f6fe03b1-2a69-4890-8f13-ebcd64f88a0e",
            Name = "Spain",
            Code2 = "ES",
            Code3 = "ESP",
            Location = new Location(40.463667, -3.74922)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "94f4735e-0ab6-457e-8b81-12036baf29bc",
            Name = "España",
            Code2 = "ES",
            Code3 = "ESP",
            Location = new Location(40.463667, -3.74922)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "d8da4aa4-e560-41d1-9cf1-8b6041572682",
            Name = "Sri Lanka",
            Code2 = "LK",
            Code3 = "LKA",
            Location = new Location(7.873054, 80.771797)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "50be91ea-65ad-407b-accf-f309e6d94e32",
            Name = "Sudan",
            Code2 = "SD",
            Code3 = "SDN",
            Location = new Location(12.862807, 30.217636)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "4c2cb14c-656c-4cfb-ab59-0ec87bb5064c",
            Name = "Suriname",
            Code2 = "SR",
            Code3 = "SUR",
            Location = new Location(3.919305, -56.027783)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "4551232e-b24a-4d1a-a58b-880b7ac09745",
            Name = "Svalbard and Jan Mayen",
            Code2 = "SJ",
            Code3 = "SJM",
            Location = new Location(77.553604, 23.670272)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "2713b1f2-f7ad-4aae-b5eb-f45c161560c7",
            Name = "Sweden",
            Code2 = "SE",
            Code3 = "SWE",
            Location = new Location(60.128161, 18.643501)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "e00139e2-044f-4d18-a5c9-7dbefea8b109",
            Name = "Switzerland",
            Code2 = "CH",
            Code3 = "CHE",
            Location = new Location(46.818188, 8.227512)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "2f82f73d-8717-4fd5-b998-e278cedc3b7f",
            Name = "Syrian Arab Republic",
            Code2 = "SY",
            Code3 = "SYR",
            Location = new Location(34.802075, 38.996815)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "d768a6be-50fa-4e86-a951-6561bab9e2b1",
            Name = "Syria",
            Code2 = "SY",
            Code3 = "SYR",
            Location = new Location(34.802075, 38.996815)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "65046973-e723-4aa9-b426-850f80fd1662",
            Name = "Taiwan, Province of China",
            Code2 = "TW",
            Code3 = "TWN",
            Location = new Location(23.69781, 120.960515)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "49bfa895-493d-4b35-b5ad-a82459d98ed8",
            Name = "Taiwan",
            Code2 = "TW",
            Code3 = "TWN",
            Location = new Location(23.69781, 120.960515)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "7d92f7b9-2110-4c44-ba1d-7a011cf9f2b5",
            Name = "Tajikistan",
            Code2 = "TJ",
            Code3 = "TJK",
            Location = new Location(38.861034, 71.276093)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "e61add25-8fa7-4f11-bcc9-a3341241e28f",
            Name = "Tanzania, United Republic of",
            Code2 = "TZ",
            Code3 = "TZA",
            Location = new Location(-6.369028, 34.888822)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "2bf87233-8c8f-4a7b-886d-b52e2bd5822b",
            Name = "Thailand",
            Code2 = "TH",
            Code3 = "THA",
            Location = new Location(15.870032, 100.992541)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "ed5bbb43-47e8-4ee0-9df2-8925afe2f4b1",
            Name = "Timor-Leste",
            Code2 = "TL",
            Code3 = "TLS",
            Location = new Location(-8.874217, 125.727539)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "8c254347-570e-45ce-868c-95d23e6a2693",
            Name = "Togo",
            Code2 = "TG",
            Code3 = "TGO",
            Location = new Location(8.619543, 0.824782)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "c6ac811c-cd25-447a-b361-96b12062da11",
            Name = "Tokelau",
            Code2 = "TK",
            Code3 = "TKL",
            Location = new Location(-8.967363, -171.855881)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "3a302f49-64f1-43e7-9f04-c4c9a9b181bb",
            Name = "Tonga",
            Code2 = "TO",
            Code3 = "TON",
            Location = new Location(-21.178986, -175.198242)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "70d670f5-412f-4bb7-958f-5226e7c09cb5",
            Name = "Trinidad and Tobago",
            Code2 = "TT",
            Code3 = "TTO",
            Location = new Location(10.691803, -61.222503)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "7985231a-d6ea-43d7-ab16-aab75143aae1",
            Name = "Tunisia",
            Code2 = "TN",
            Code3 = "TUN",
            Location = new Location(33.886917, 9.537499)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "066af74e-26f9-4e21-a6e9-6ada818ccaa4",
            Name = "Turkey",
            Code2 = "TR",
            Code3 = "TUR",
            Location = new Location(38.963745, 35.243322)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "81ab5203-120c-4e32-8193-303664dedb49",
            Name = "Turkmenistan",
            Code2 = "TM",
            Code3 = "TKM",
            Location = new Location(38.969719, 59.556278)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "11ddf45f-a653-423c-a454-7c34f1f38670",
            Name = "Turks and Caicos Islands",
            Code2 = "TC",
            Code3 = "TCA",
            Location = new Location(21.694025, -71.797928)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "a57d6d3c-9bb0-4abd-b4b9-7399278dc81f",
            Name = "Tuvalu",
            Code2 = "TV",
            Code3 = "TUV",
            Location = new Location(-7.109535, 177.64933)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "f3c6a1fc-c117-43a4-84b2-c6ef69a028e4",
            Name = "Uganda",
            Code2 = "UG",
            Code3 = "UGA",
            Location = new Location(1.373333, 32.290275)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "d430ac13-81b6-4265-a589-1a9a8c5678bc",
            Name = "Ukraine",
            Code2 = "UA",
            Code3 = "UKR",
            Location = new Location(48.379433, 31.16558)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "d229597d-95f5-4a1b-98c0-019233369a07",
            Name = "United Arab Emirates",
            Code2 = "AE",
            Code3 = "ARE",
            Location = new Location(23.424076, 53.847818)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "00086250-0b35-4988-89e4-4b00b8fbe6b8",
            Name = "United Kingdom of Great Britain and Northern Ireland",
            Code2 = "GB",
            Code3 = "GBR",
            Location = new Location(55.378051, -3.435973)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "80859453-05bd-4a1c-8609-1e5be734dac3",
            Name = "United Kingdom",
            Code2 = "GB",
            Code3 = "GBR",
            Location = new Location(55.378051, -3.435973)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "1e7f8d3d-98b9-488e-b056-495e69c7a9a1",
            Name = "United States of America",
            Code2 = "US",
            Code3 = "USA",
            Location = new Location(37.09024, -95.712891)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "0fae96d3-1ede-43f9-a90c-cf3370c9f8f2",
            Name = "United States",
            Code2 = "US",
            Code3 = "USA",
            Location = new Location(37.09024, -95.712891)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "9cad0ff2-8249-410c-b286-73510d406c1c",
            Name = "United States Minor Outlying Islands",
            Code2 = "UM",
            Code3 = "UMI",
            Location = new Location(0, 0)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "20ebc9fe-4e83-4085-b681-d16876fbb402",
            Name = "Uruguay",
            Code2 = "UY",
            Code3 = "URY",
            Location = new Location(-32.522779, -55.765835)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "71befb57-c159-458f-bdd0-e11c68c9c4ac",
            Name = "Uzbekistan",
            Code2 = "UZ",
            Code3 = "UZB",
            Location = new Location(41.377491, 64.585262)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "b2e13f6b-27db-40c3-8d2f-96b2f493b850",
            Name = "Vanuatu",
            Code2 = "VU",
            Code3 = "VUT",
            Location = new Location(-15.376706, 166.959158)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "5ef76278-12d3-438d-b36b-6d3d878de255",
            Name = "Venezuela (Bolivarian Republic of)",
            Code2 = "VE",
            Code3 = "VEN",
            Location = new Location(6.42375, -66.58973)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "63d9d7e1-c6b7-4d17-a53d-b9b1403f0402",
            Name = "Venezuela",
            Code2 = "VE",
            Code3 = "VEN",
            Location = new Location(6.42375, -66.58973)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "4b4b52b8-4af5-4296-a7d6-fa1437deb0bb",
            Name = "Viet Nam",
            Code2 = "VN",
            Code3 = "VNM",
            Location = new Location(14.058324, 108.277199)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "3c5ed6d6-01e2-4912-a79c-3a3a1c35e27a",
            Name = "Virgin Islands (British)",
            Code2 = "VG",
            Code3 = "VGB",
            Location = new Location(18.420695, -64.639968)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "0097ae3d-3acb-42a9-91f2-9d163f9af781",
            Name = "Virgin Isles (British)",
            Code2 = "VG",
            Code3 = "VGB",
            Location = new Location(18.420695, -64.639968)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "5efbb017-e6f2-478d-bacb-4a5b5fccd499",
            Name = "Virgin Islands (U.S.)",
            Code2 = "VI",
            Code3 = "VIR",
            Location = new Location(18.335765, -64.896335)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "4636fc72-14d7-4c75-a68a-0d321f7ecf9f",
            Name = "Wallis and Futuna",
            Code2 = "WF",
            Code3 = "WLF",
            Location = new Location(-13.768752, -177.156097)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "a2a63d40-eb6f-464a-b87c-103adb838817",
            Name = "Western Sahara",
            Code2 = "EH",
            Code3 = "ESH",
            Location = new Location(24.215527, -12.885834)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "db2d40f8-d7b6-466e-ac79-d1b0a6df40a1",
            Name = "Yemen",
            Code2 = "YE",
            Code3 = "YEM",
            Location = new Location(15.552727, 48.516388)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "5a70524e-1a39-4a90-a80f-90b09a20344e",
            Name = "Zambia",
            Code2 = "ZM",
            Code3 = "ZMB",
            Location = new Location(-13.133897, 27.849332)
         });
         builder.Entity<Country>().HasData(new Country() {
            Id = "b66d53b6-ca6b-4324-834b-9bfc82cebbaa",
            Name = "Zimbabwe",
            Code2 = "ZW",
            Code3 = "ZWE",
            Location = new Location(-19.015438, 29.154857)
         });
      }
   }
}
