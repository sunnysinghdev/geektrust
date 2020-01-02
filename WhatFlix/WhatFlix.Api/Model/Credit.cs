using System;
using System.Collections.Generic;
using CsvHelper.Configuration.Attributes;
using WhatFlix.Common;
namespace WhatFlix.Api.Model
{
    //285,
    //Pirates of the Caribbean: At World's End,
    //"[
        //{""cast_id"": 4, ""character"": ""Captain Jack Sparrow"", ""credit_id"": ""52fe4232c3a36847f800b50d"", ""gender"": 2, ""id"": 85, ""name"": ""Johnny Depp"", ""order"": 0},
        //{""cast_id"": 5, ""character"": ""Will Turner"", ""credit_id"": ""52fe4232c3a36847f800b511"", ""gender"": 2, ""id"": 114, ""name"": ""Orlando Bloom"", ""order"": 1},
        //{""cast_id"": 6, ""character"": ""Elizabeth Swann"", ""credit_id"": ""52fe4232c3a36847f800b515"", ""gender"": 1, ""id"": 116, ""name"": ""Keira Knightley"", ""order"": 2}, 
        //{""cast_id"": 12, ""character"": ""William \""Bootstrap Bill\"" Turner"", ""credit_id"": ""52fe4232c3a36847f800b52d"", ""gender"": 2, ""id"": 1640, ""name"": ""Stellan Skarsg\u00e5rd"", ""order"": 3}, 
        //{""cast_id"": 10, ""character"": ""Captain Sao Feng"", ""credit_id"": ""52fe4232c3a36847f800b525"", ""gender"": 2, ""id"": 1619, ""name"": ""Chow Yun-fat"", ""order"": 4}, 
        //{""cast_id"": 9, ""character"": ""Captain Davy Jones"", ""credit_id"": ""52fe4232c3a36847f800b521"", ""gender"": 2, ""id"": 2440, ""name"": ""Bill Nighy"", ""order"": 5}, 
        //{""cast_id"": 7, ""character"": ""Captain Hector Barbossa"", ""credit_id"": ""52fe4232c3a36847f800b519"", ""gender"": 2, ""id"": 118, ""name"": ""Geoffrey Rush"", ""order"": 6},
         //{""cast_id"": 14, ""character"": ""Admiral James Norrington"", ""credit_id"": ""52fe4232c3a36847f800b535"", ""gender"": 2, ""id"": 1709, ""name"": ""Jack Davenport"", ""order"": 7}, {""cast_id"": 13, ""character"": ""Joshamee Gibbs"", ""credit_id"": ""52fe4232c3a36847f800b531"", ""gender"": 2, ""id"": 2449, ""name"": ""Kevin McNally"", ""order"": 8}, {""cast_id"": 11, ""character"": ""Lord Cutler Beckett"", ""credit_id"": ""52fe4232c3a36847f800b529"", ""gender"": 2, ""id"": 2441, ""name"": ""Tom Hollander"", ""order"": 9}, {""cast_id"": 19, ""character"": ""Tia Dalma"", ""credit_id"": ""52fe4232c3a36847f800b549"", ""gender"": 1, ""id"": 2038, ""name"": ""Naomie Harris"", ""order"": 10}, {""cast_id"": 8, ""character"": ""Governor Weatherby Swann"", ""credit_id"": ""52fe4232c3a36847f800b51d"", ""gender"": 2, ""id"": 378, ""name"": ""Jonathan Pryce"", ""order"": 11}, {""cast_id"": 37, ""character"": ""Captain Teague Sparrow"", ""credit_id"": ""52fe4232c3a36847f800b5b3"", ""gender"": 2, ""id"": 1430, ""name"": ""Keith Richards"", ""order"": 12}, {""cast_id"": 16, ""character"": ""Pintel"", ""credit_id"": ""52fe4232c3a36847f800b53d"", ""gender"": 2, ""id"": 1710, ""name"": ""Lee Arenberg"", ""order"": 13}, {""cast_id"": 15, ""character"": ""Ragetti"", ""credit_id"": ""52fe4232c3a36847f800b539"", ""gender"": 2, ""id"": 1711, ""name"": ""Mackenzie Crook"", ""order"": 14}, {""cast_id"": 18, ""character"": ""Lieutenant Theodore Groves"", ""credit_id"": ""52fe4232c3a36847f800b545"", ""gender"": 2, ""id"": 4031, ""name"": ""Greg Ellis"", ""order"": 15}, {""cast_id"": 55, ""character"": ""Cotton"", ""credit_id"": ""57e28d2ec3a3681a01005b5c"", ""gender"": 2, ""id"": 1715, ""name"": ""David Bailie"", ""order"": 16}, {""cast_id"": 17, ""character"": ""Marty"", ""credit_id"": ""52fe4232c3a36847f800b541"", ""gender"": 2, ""id"": 4030, ""name"": ""Martin Klebba"", ""order"": 17}, {""cast_id"": 57, ""character"": ""Ian Mercer"", ""credit_id"": ""57e28d78c3a36808b900bf4f"", ""gender"": 0, ""id"": 939, ""name"": ""David Schofield"", ""order"": 18}, {""cast_id"": 62, ""character"": ""Scarlett"", ""credit_id"": ""57e28ec5c3a3681a50005855"", ""gender"": 1, ""id"": 2450, ""name"": ""Lauren Maher"", ""order"": 19}, {""cast_id"": 63, ""character"": ""Giselle"", ""credit_id"": ""57e28ed692514123f5005635"", ""gender"": 1, ""id"": 2452, ""name"": ""Vanessa Branch"", ""order"": 20}, {""cast_id"": 60, ""character"": ""Mullroy"", ""credit_id"": ""57e28db2c3a3681a01005bc7"", ""gender"": 2, ""id"": 1714, ""name"": ""Angus Barnett"", ""order"": 21}, {""cast_id"": 59, ""character"": ""Murtogg"", ""credit_id"": ""57e28da192514118f7006008"", ""gender"": 0, ""id"": 1713, ""name"": ""Giles New"", ""order"": 22}, {""cast_id"": 58, ""character"": ""Tai Huang"", ""credit_id"": ""57e28d8ec3a3681a01005bab"", ""gender"": 2, ""id"": 22075, ""name"": ""Reggie Lee"", ""order"": 23}, {""cast_id"": 64, ""character"": ""Henry Turner"", ""credit_id"": ""57e29119925141151100a6cc"", ""gender"": 2, ""id"": 61259, ""name"": ""Dominic Scott Kay"", ""order"": 24}, {""cast_id"": 39, ""character"": ""Mistress Ching"", ""credit_id"": ""52fe4232c3a36847f800b5bd"", ""gender"": 1, ""id"": 33500, ""name"": ""Takayo Fischer"", ""order"": 25}, {""cast_id"": 40, ""character"": ""Lieutenant Greitzer"", ""credit_id"": ""52fe4232c3a36847f800b5c1"", ""gender"": 2, ""id"": 1224149, ""name"": ""David Meunier"", ""order"": 26}, {""cast_id"": 49, ""character"": ""Hadras"", ""credit_id"": ""56d1871c92514174680010cf"", ""gender"": 2, ""id"": 429401, ""name"": ""Ho-Kwan Tse"", ""order"": 27}, {""cast_id"": 56, ""character"": ""Clacker"", ""credit_id"": ""57e28d4b92514125710055cb"", ""gender"": 0, ""id"": 1123, ""name"": ""Andy Beckwith"", ""order"": 28}, {""cast_id"": 51, ""character"": ""Penrod"", ""credit_id"": ""56ec8c14c3a3682260003c53"", ""gender"": 2, ""id"": 1056117, ""name"": ""Peter Donald Badalamenti II"", ""order"": 29}, {""cast_id"": 61, ""character"": ""Cotton's Parrot (voice)"", ""credit_id"": ""57e28dcc9251412463005678"", ""gender"": 2, ""id"": 21700, ""name"": ""Christopher S. Capp"", ""order"": 30}, {""cast_id"": 65, ""character"": ""Captain Teague"", ""credit_id"": ""58bc2a37c3a368663003740b"", ""gender"": 2, ""id"": 1430, ""name"": ""Keith Richards"", ""order"": 31}, {""cast_id"": 66, ""character"": ""Captain Jocard"", ""credit_id"": ""58bc2a8e925141609e03a179"", ""gender"": 2, ""id"": 2603, ""name"": ""Hakeem Kae-Kazim"", ""order"": 32}, {""cast_id"": 67, ""character"": ""Captain Ammand"", ""credit_id"": ""58e2a21ac3a36872af00f9c2"", ""gender"": 0, ""id"": 70577, ""name"": ""Ghassan Massoud"", ""order"": 33}]",
        //"[
        //{""credit_id"": ""52fe4232c3a36847f800b579"", ""department"": ""Camera"", ""gender"": 2, ""id"": 120, ""job"": ""Director of Photography"", ""name"": ""Dariusz Wolski""}, 
        //{""credit_id"": ""52fe4232c3a36847f800b4fd"", ""department"": ""Directing"", ""gender"": 2, ""id"": 1704, ""job"": ""Director"", ""name"": ""Gore Verbinski""}, 
        //{""credit_id"": ""52fe4232c3a36847f800b54f"", ""department"": ""Production"", ""gender"": 2, ""id"": 770, ""job"": ""Producer"", ""name"": ""Jerry Bruckheimer""}, {""credit_id"": ""52fe4232c3a36847f800b503"", ""department"": ""Writing"", ""gender"": 2, ""id"": 1705, ""job"": ""Screenplay"", ""name"": ""Ted Elliott""}, {""credit_id"": ""52fe4232c3a36847f800b509"", ""department"": ""Writing"", ""gender"": 2, ""id"": 1706, ""job"": ""Screenplay"", ""name"": ""Terry Rossio""}, {""credit_id"": ""52fe4232c3a36847f800b57f"", ""department"": ""Editing"", ""gender"": 0, ""id"": 1721, ""job"": ""Editor"", ""name"": ""Stephen E. Rivkin""}, {""credit_id"": ""52fe4232c3a36847f800b585"", ""department"": ""Editing"", ""gender"": 2, ""id"": 1722, ""job"": ""Editor"", ""name"": ""Craig Wood""}, {""credit_id"": ""52fe4232c3a36847f800b573"", ""department"": ""Sound"", ""gender"": 2, ""id"": 947, ""job"": ""Original Music Composer"", ""name"": ""Hans Zimmer""}, {""credit_id"": ""52fe4232c3a36847f800b555"", ""department"": ""Production"", ""gender"": 2, ""id"": 2444, ""job"": ""Executive Producer"", ""name"": ""Mike Stenson""}, 
        //{""credit_id"": ""52fe4232c3a36847f800b561"", ""department"": ""Production"", ""gender"": 2, ""id"": 2445, ""job"": ""Producer"", ""name"": ""Eric McLeod""}, 
        //{""credit_id"": ""52fe4232c3a36847f800b55b"", ""department"": ""Production"", ""gender"": 2, ""id"": 2446, ""job"": ""Producer"", ""name"": ""Chad Oman""}, {""credit_id"": ""52fe4232c3a36847f800b567"", ""department"": ""Production"", ""gender"": 0, ""id"": 2447, ""job"": ""Producer"", ""name"": ""Peter Kohn""}, {""credit_id"": ""52fe4232c3a36847f800b56d"", ""department"": ""Production"", ""gender"": 0, ""id"": 2448, ""job"": ""Producer"", ""name"": ""Pat Sandston""}, {""credit_id"": ""52fe4232c3a36847f800b58b"", ""department"": ""Production"", ""gender"": 1, ""id"": 2215, ""job"": ""Casting"", ""name"": ""Denise Chamian""}, {""credit_id"": ""52fe4232c3a36847f800b597"", ""department"": ""Art"", ""gender"": 2, ""id"": 1226, ""job"": ""Production Design"", ""name"": ""Rick Heinrichs""}, {""credit_id"": ""52fe4232c3a36847f800b59d"", ""department"": ""Art"", ""gender"": 2, ""id"": 553, ""job"": ""Art Direction"", ""name"": ""John Dexter""}, {""credit_id"": ""52fe4232c3a36847f800b591"", ""department"": ""Production"", ""gender"": 1, ""id"": 3311, ""job"": ""Casting"", ""name"": ""Priscilla John""}, {""credit_id"": ""52fe4232c3a36847f800b5a3"", ""department"": ""Art"", ""gender"": 1, ""id"": 4032, ""job"": ""Set Decoration"", ""name"": ""Cheryl Carasik""}, {""credit_id"": ""52fe4232c3a36847f800b5a9"", ""department"": ""Costume & Make-Up"", ""gender"": 0, ""id"": 4033, ""job"": ""Costume Design"", ""name"": ""Liz Dann""}, {""credit_id"": ""52fe4232c3a36847f800b5af"", ""department"": ""Costume & Make-Up"", ""gender"": 1, ""id"": 4034, ""job"": ""Costume Design"", ""name"": ""Penny Rose""}, {""credit_id"": ""56427ce8c3a3686a53000d8b"", ""department"": ""Sound"", ""gender"": 2, ""id"": 5132, ""job"": ""Music Supervisor"", ""name"": ""Bob Badami""}, {""credit_id"": ""55993c15c3a36855db002f33"", ""department"": ""Art"", ""gender"": 2, ""id"": 146439, ""job"": ""Conceptual Design"", ""name"": ""James Ward Byrkit""}, {""credit_id"": ""52fe4232c3a36847f800b5b9"", ""department"": ""Costume & Make-Up"", ""gender"": 1, ""id"": 406204, ""job"": ""Makeup Department Head"", ""name"": ""Ve Neill""}, {""credit_id"": ""56e47f7892514132690017bd"", ""department"": ""Crew"", ""gender"": 2, ""id"": 1259516, ""job"": ""Stunts"", ""name"": ""John Dixon""}, {""credit_id"": ""5740be639251416597000849"", ""department"": ""Crew"", ""gender"": 0, ""id"": 1336716, ""job"": ""CGI Supervisor"", ""name"": ""Dottie Starling""},
        //{""credit_id"": ""56427c639251412fc8000dc1"", ""department"": ""Directing"", ""gender"": 1, ""id"": 1344278, ""job"": ""Script Supervisor"", ""name"": ""Pamela Alch""},
        //{""credit_id"": ""57083101c3a3681d320004e6"", ""department"": ""Crew"", ""gender"": 0, ""id"": 1368867, ""job"": ""Special Effects Coordinator"", ""name"": ""Allen Hall""}, 
        //{""credit_id"": ""56427d5ec3a3686a62000d4a"", ""department"": ""Sound"", ""gender"": 0, ""id"": 1368884, ""job"": ""Music Editor"", ""name"": ""Melissa Muik""}, 
        //{""credit_id"": ""56427c7b9251412fd4000e07"", ""department"": ""Directing"", ""gender"": 1, ""id"": 1395290, ""job"": ""Script Supervisor"", ""name"": ""Sharron Reynolds""},
        //{""credit_id"": ""56427d2bc3a3686a53000d9b"", ""department"": ""Sound"", ""gender"": 0, ""id"": 1399327, ""job"": ""Music Editor"", ""name"": ""Barbara McDermott""}, 
        //{""credit_id"": ""56427cb4c3a3686a53000d87"", ""department"": ""Directing"", ""gender"": 1, ""id"": 1400738, ""job"": ""Script Supervisor"", ""name"": ""Karen Golden""}, 
        //{""credit_id"": ""56427d169251412fd4000e23"", ""department"": ""Sound"", ""gender"": 0, ""id"": 1534197, ""job"": ""Music Editor"", ""name"": ""Katie Greathouse""}
        //]"

    public class Credit
    {
        public int Id {get;set;}
        public string Title {get; set;}
        //Director
        public List<Crew> Crews = new List<Crew>(); 

        //Actor 
        public List<Cast> Casts = new List<Cast>();
    }
    public class CreditParse
    {
        //movie_id,title,cast,crew
        [Name("movie_id")]
        public int Id { get; set; }
        [Name("title")]
        public string Title { get; set; }
        [Name("cast")]
        public string Cast { get; set; }
        [Name("crew")]
        public string Crew { get; set; }
        // public string Actor { get; set; }
        // public string Language { get; set; }
    }
    public class Cast{
        
        [Name("name")]
        public string Name { get; set; }
        
        [Name("id")]
        public int Id { get; set; }
        [Name("order")]
        public int Order { get; set; }

    }
    public class Crew {
        
        [Name("id")]
        public int Id { get; set; }

        [Name("name")]
        public string Name { get; set; }
        
        [Name("job")]
        public string Job { get; set; }

    }
}