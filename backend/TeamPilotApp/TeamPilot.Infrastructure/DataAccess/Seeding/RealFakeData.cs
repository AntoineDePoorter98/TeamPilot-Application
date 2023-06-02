using TeamPilot.Domain.Entities;

namespace TeamPilot.Infrastructure.DataAccess.Seeding;

public static class RealFakeData
{
    public static Lists GetRealFakeData()
    {
        List<Team> listOfTeams = new();
        List<Player> listOfPlayers = new();
        List<TeamManager> listOfTeamManagers = new();
        List<TournamentManager> listOfTourManagers = new();
        List<Tournament> listOfTournaments = new();
        List<Article> listOfArticles = new();
        Lists allLists = new();

        // ===========================================================
        // ===========================================================
        listOfTeamManagers = new List<TeamManager>()
        {
            new TeamManager
            {
                UserId = Guid.NewGuid(),
                FirstName = "Amiran",
                LastName = "Rekhviashvili",
                AvatarUrl = "https://liquipedia.net/commons/images/c/cb/Ami_NAVI_Junior.jpg",
                Bio = "i am team manager of navi",
                Email = "ami@navi.com",
                Nickname = "ami",
                PasswordHash = "$2a$11$UHiAjLF0wJN53bCquEqnqOBrS8uQZ9MZzX0wj264IxZX/0tG12/FC"
            },
            new TeamManager
            {
                UserId = Guid.NewGuid(),
                FirstName = "Robert",
                LastName = "Dahlstrom",
                AvatarUrl = "https://liquipedia.net/commons/images/thumb/c/ca/RobbaN_at_BLAST_Spring_Finals_2022.jpg/600px-RobbaN_at_BLAST_Spring_Finals_2022.jpg",
                Bio = "i am team manager of faze",
                Email = "robban@faze.com",
                Nickname = "RobbaN",
            },
            new TeamManager
            {
                UserId = Guid.NewGuid(),
                FirstName = "Jan",
                LastName = "Muller",
                AvatarUrl = "https://liquipedia.net/commons/images/thumb/5/5c/Swani_at_BLAST_Paris_Major_2023_EU_RMR.jpeg/600px-Swani_at_BLAST_Paris_Major_2023_EU_RMR.jpeg",
                Bio = "i am team manager of g2",
                Email = "swani@g2.com",
                Nickname = "Swani",
            },
            new TeamManager
            {
                UserId = Guid.NewGuid(),
                FirstName = "Dastan",
                LastName = "Aqbaev",
                AvatarUrl = "https://liquipedia.net/commons/images/thumb/f/f3/Dastan_at_Antwerp_Major_2022_EU_RMR.jpg/600px-Dastan_at_Antwerp_Major_2022_EU_RMR.jpg",
                Bio = "i am team manager of virtus pro",
                Email = "dastan@vp.com",
                Nickname = "dastan",
            },
            new TeamManager
            {
                UserId = Guid.NewGuid(),
                FirstName = "Jamie",
                LastName = "Hall",
                AvatarUrl = "https://liquipedia.net/commons/images/thumb/3/37/Keita_at_IEM_Rio_Major_2022.jpg/600px-Keita_at_IEM_Rio_Major_2022.jpg",
                Bio = "i am team manager of fnatic",
                Email = "keita@fnatic.com",
                Nickname = "keita",
            },
            new TeamManager
            {
                UserId = Guid.NewGuid(),
                FirstName = "Casper",
                LastName = "Due",
                AvatarUrl = "https://liquipedia.net/commons/images/thumb/3/31/Ruggah_at_Antwerp_Major_2022_EU_RMR.jpg/600px-Ruggah_at_Antwerp_Major_2022_EU_RMR.jpg",
                Bio = "i am team manager of og",
                Email = "ruggah@og.com",
                Nickname = "ruggah",
            },
            new TeamManager
            {
                UserId = Guid.NewGuid(),
                FirstName = "Richard",
                LastName = "Landstrom",
                AvatarUrl = "https://liquipedia.net/commons/images/thumb/4/46/Xizt_at_BLAST_Paris_Major_2023_EU_RMR.jpeg/600px-Xizt_at_BLAST_Paris_Major_2023_EU_RMR.jpeg",
                Bio = "i am team manager of heroic",
                Email = "xizt@heroic.com",
                Nickname = "Xizt",
            },
            new TeamManager
            {
                UserId = Guid.NewGuid(),
                FirstName = "Nicholas",
                LastName = "Nogueira",
                AvatarUrl = "https://liquipedia.net/commons/images/thumb/6/65/Guerri_%40_EPL_S15.jpg/600px-Guerri_%40_EPL_S15.jpg",
                Bio = "i am team manager of furia",
                Email = "guerri@furia.com",
                Nickname = "guerri",
            },
            new TeamManager
            {
                UserId = Guid.NewGuid(),
                FirstName = "Dennis",
                LastName = "Nielsen",
                AvatarUrl = "https://liquipedia.net/commons/images/thumb/6/6c/MOUZ_sycrone_2022.jpg/600px-MOUZ_sycrone_2022.jpg",
                Bio = "i am team manager of mouz",
                Email = "sycrone@mouz.com",
                Nickname = "sycrone",
            },
            new TeamManager
            {
                UserId = Guid.NewGuid(),
                FirstName = "Danny",
                LastName = "Sorensen",
                AvatarUrl = "https://liquipedia.net/commons/images/thumb/a/a1/Zonic_at_Antwerp_Major_2022_EU_RMR.jpg/600px-Zonic_at_Antwerp_Major_2022_EU_RMR.jpg",
                Bio = "i am team manager of vitality",
                Email = "zonic@vitality.com",
                Nickname = "zonic",
            },
            new TeamManager
            {
                UserId = Guid.NewGuid(),
                FirstName = "Eetu",
                LastName = "Saha",
                AvatarUrl = "https://liquipedia.net/commons/images/thumb/4/4f/SAw_at_CCT_Central_Europe_Malta_Finals.jpg/600px-SAw_at_CCT_Central_Europe_Malta_Finals.jpg",
                Bio = "i am team manager of ence",
                Email = "saw@ence.com",
                Nickname = "sAw",
            },
            new TeamManager
            {
                UserId = Guid.NewGuid(),
                FirstName = "Anton",
                LastName = "Van Gorp",
                AvatarUrl = "https://liquipedia.net/commons/images/thumb/9/99/AntOoNNN_%40_COL_Copenhagen_Bootcamp_2021.jpg/600px-AntOoNNN_%40_COL_Copenhagen_Bootcamp_2021.jpg",
                Bio = "i am team manager of complexity",
                Email = "anton@complexity.com",
                Nickname = "AntO_oNNN",
            },
            new TeamManager
            {
                UserId = Guid.NewGuid(),
                FirstName = "Daniel",
                LastName = "Narancic",
                AvatarUrl = "https://liquipedia.net/commons/images/thumb/a/ab/DjL_at_BLAST_Paris_Major_2023_EU_RMR.jpeg/600px-DjL_at_BLAST_Paris_Major_2023_EU_RMR.jpeg",
                Bio = "i am team manager of nip",
                Email = "djl@nip.com",
                Nickname = "djL",
            },
            new TeamManager
            {
                UserId = Guid.NewGuid(),
                FirstName = "Damian",
                LastName = "Steele",
                AvatarUrl = "https://liquipedia.net/commons/images/thumb/e/e0/Daps_%40_BLAST_Premier_Abu_Dhabi_2022.jpg/600px-Daps_%40_BLAST_Premier_Abu_Dhabi_2022.jpg",
                Bio = "i am team manager of liquid",
                Email = "daps@liquid.com",
                Nickname = "daps",
                PasswordHash = "$2a$11$UHiAjLF0wJN53bCquEqnqOBrS8uQZ9MZzX0wj264IxZX/0tG12/FC"
            },
            new TeamManager
            {
                UserId = Guid.NewGuid(),
                FirstName = "Henrique",
                LastName = "Waku",
                AvatarUrl = "https://liquipedia.net/commons/images/thumb/4/43/Rikz_at_BLAST_Spring_Finals_2022.jpg/600px-Rikz_at_BLAST_Spring_Finals_2022.jpg",
                Bio = "i am team manager of pain",
                Email = "rikz@pain.com",
                Nickname = "rikz",
            },
            new TeamManager
            {
                UserId = Guid.NewGuid(),
                FirstName = "Peter",
                LastName = "Ardenskjold",
                AvatarUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c5/Kasper_Hvidt_01.jpg/220px-Kasper_Hvidt_01.jpg",
                Bio = "i am team manager of astralis",
                Email = "casle@astralis.com",
                Nickname = "casle",
            }
        };

        listOfTeams = new List<Team>()
        {
            new Team
            {
                TeamId = Guid.NewGuid(),
                TeamName = "NAVI",
                AvatarUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/a/ac/NaVi_logo.svg/263px-NaVi_logo.svg.png",
                TeamManagerId = listOfTeamManagers[0].UserId
            },
            new Team
            {
                TeamId = Guid.NewGuid(),
                TeamName = "FaZe",
                AvatarUrl = "https://upload.wikimedia.org/wikipedia/commons/4/4d/Faze_Clan.svg",
                TeamManagerId = listOfTeamManagers[1].UserId
            },
            new Team
            {
                TeamId = Guid.NewGuid(),
                TeamName = "G2",
                AvatarUrl = "https://upload.wikimedia.org/wikipedia/fr/thumb/e/e4/G2_Esports.svg/1200px-G2_Esports.svg.png",
                TeamManagerId = listOfTeamManagers[2].UserId
            },
            new Team
            {
                TeamId = Guid.NewGuid(),
                TeamName = "VirtusPro",
                AvatarUrl = "https://upload.wikimedia.org/wikipedia/en/3/3b/Virtus_pro_logo_new.png",
                TeamManagerId = listOfTeamManagers[3].UserId
            },
            new Team
            {
                TeamId = Guid.NewGuid(),
                TeamName = "Fnatic",
                AvatarUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/4/43/Esports_organization_Fnatic_logo.svg/330px-Esports_organization_Fnatic_logo.svg.png",
                TeamManagerId = listOfTeamManagers[4].UserId
            },
            new Team
            {
                TeamId = Guid.NewGuid(),
                TeamName = "OG",
                AvatarUrl = "https://upload.wikimedia.org/wikipedia/en/2/28/OG_%28Redbull%29.png",
                TeamManagerId = listOfTeamManagers[5].UserId
            },
            new Team
            {
                TeamId = Guid.NewGuid(),
                TeamName = "Heroic",
                AvatarUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/8f/Heroic_2023_logo.png/330px-Heroic_2023_logo.png",
                TeamManagerId = listOfTeamManagers[6].UserId
            },
            new Team
            {
                TeamId = Guid.NewGuid(),
                TeamName = "Furia",
                AvatarUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/a/ad/FURIA_Esports_logo.svg/218px-FURIA_Esports_logo.svg.png",
                TeamManagerId = listOfTeamManagers[7].UserId
            },
            new Team
            {
                TeamId = Guid.NewGuid(),
                TeamName = "MOUZ",
                AvatarUrl = "https://prosettings.net/wp-content/uploads/mouz.png",
                TeamManagerId = listOfTeamManagers[8].UserId
            },
            new Team
            {
                TeamId = Guid.NewGuid(),
                TeamName = "Vitality",
                AvatarUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/4/49/Team_Vitality_logo.svg/263px-Team_Vitality_logo.svg.png",
                TeamManagerId = listOfTeamManagers[9].UserId
            },
            new Team
            {
                TeamId = Guid.NewGuid(),
                TeamName = "ENCE",
                AvatarUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/a/a7/Ence_%28esports%29_logo.svg/330px-Ence_%28esports%29_logo.svg.png",
                TeamManagerId = listOfTeamManagers[10].UserId
            },
            new Team
            {
                TeamId = Guid.NewGuid(),
                TeamName = "Complexity",
                AvatarUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/bc/Complexity_Gaming_Logo_-_Blue.png/330px-Complexity_Gaming_Logo_-_Blue.png",
                TeamManagerId = listOfTeamManagers[11].UserId
            },
            new Team
            {
                TeamId = Guid.NewGuid(),
                TeamName = "NiP",
                AvatarUrl = "https://prosettings.net/acd-cgi/img/v1/wp-content/uploads/ninjas-in-pyjamas.png?dpr=1",
                TeamManagerId = listOfTeamManagers[12].UserId
            },
            new Team
            {
                TeamId = Guid.NewGuid(),
                TeamName = "Liquid",
                AvatarUrl = "https://prosettings.net/wp-content/uploads/team-liquid.svg",
                TeamManagerId = listOfTeamManagers[13].UserId
            },
            new Team
            {
                TeamId = Guid.NewGuid(),
                TeamName = "paiN",
                AvatarUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/e/e5/PaiN_Gaming_logo.svg/330px-PaiN_Gaming_logo.svg.png",
                TeamManagerId = listOfTeamManagers[14].UserId
            },
            new Team
            {
                TeamId = Guid.NewGuid(),
                TeamName = "Astralis",
                AvatarUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/7d/Astralis_logo.svg/203px-Astralis_logo.svg.png",
                TeamManagerId = listOfTeamManagers[15].UserId
            },
        };

        listOfPlayers = new List<Player>()
        {
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "s1mple",
                FirstName = "Oleksandr",
                LastName = "Kostyliev",
                Bio = "[CAPTAIN] ingame leader for navi since 2016",
                Email = "s1mple@navi.com",
                MonthlySalary = 5000m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/s1mple.png",
                TeamId = listOfTeams[0].TeamId,
                PasswordHash = "$2a$11$UHiAjLF0wJN53bCquEqnqOBrS8uQZ9MZzX0wj264IxZX/0tG12/FC"
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "electroNic",
                FirstName = "Denis",
                LastName = "Sharipov",
                Bio = "second one of the team",
                Email = "elec@navi.com",
                MonthlySalary = 3000m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/electronic.png",
                TeamId = listOfTeams[0].TeamId,
                PasswordHash = "$2a$11$UHiAjLF0wJN53bCquEqnqOBrS8uQZ9MZzX0wj264IxZX/0tG12/FC"
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "Perfecto",
                FirstName = "Ilya",
                LastName = "Zalutskiy",
                Bio = "third one of the team",
                Email = "perfecto@navi.com",
                MonthlySalary = 3000m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/perfecto.png",
                TeamId = listOfTeams[0].TeamId,
                PasswordHash = "$2a$11$UHiAjLF0wJN53bCquEqnqOBrS8uQZ9MZzX0wj264IxZX/0tG12/FC"
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "b1t",
                FirstName = "Valeriy",
                LastName = "Vakhovskiy",
                Bio = "fourth one of the team",
                Email = "b1t@navi.com",
                MonthlySalary = 3000m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/b1t.png",
                TeamId = listOfTeams[0].TeamId,
                PasswordHash = "$2a$11$UHiAjLF0wJN53bCquEqnqOBrS8uQZ9MZzX0wj264IxZX/0tG12/FC"
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "npl",
                FirstName = "Andrii",
                LastName = "Kukharskyi",
                Bio = "fifth one of the team",
                Email = "npl@navi.com",
                MonthlySalary = 3000m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/npl.png",
                TeamId = listOfTeams[0].TeamId,
                PasswordHash = "$2a$11$UHiAjLF0wJN53bCquEqnqOBrS8uQZ9MZzX0wj264IxZX/0tG12/FC"
            },
            // =====================================
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "karrigan",
                FirstName = "Finn",
                LastName = "Andersen",
                Bio = "[CAPTAIN] ingame leader",
                Email = "karrigan@faze.com",
                MonthlySalary = 5400m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/karrigan.png",
                TeamId = listOfTeams[1].TeamId,
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "rain",
                FirstName = "Havard",
                LastName = "Nygaard",
                Bio = "second one of the team",
                Email = "rain@faze.com",
                MonthlySalary = 3000m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/rain.png",
                TeamId = listOfTeams[1].TeamId,
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "Twistzz",
                FirstName = "Russel",
                LastName = "Van Dulken",
                Bio = "third one of the team",
                Email = "twistzz@faze.com",
                MonthlySalary = 2000m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/twistzz.png",
                TeamId = listOfTeams[1].TeamId,
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "ropz",
                FirstName = "Robin",
                LastName = "Kool",
                Bio = "fourth one of the team",
                Email = "ropz@faze.com",
                MonthlySalary = 3000m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/ropz.png",
                TeamId = listOfTeams[1].TeamId,
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "broky",
                FirstName = "Helvijs",
                LastName = "Saukants",
                Bio = "fifth one of the team",
                Email = "broky@faze.com",
                MonthlySalary = 3000m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/broky.png",
                TeamId = listOfTeams[1].TeamId,
            },
            // ===================================
            new Player
            {
                UserId = new Guid("C356516D-97A7-45B2-9CE2-1646E12AB822"),
                Nickname = "NiKo",
                FirstName = "Nikola",
                LastName = "Kovac",
                Bio = "[CAPTAIN] ingame leader",
                Email = "niko@g2.com",
                MonthlySalary = 5400m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/niko.png",
                TeamId = listOfTeams[2].TeamId,
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "huNter-",
                FirstName = "Nemanja",
                LastName = "Kovac",
                Bio = "second one of the team",
                Email = "hunter@g2.com",
                MonthlySalary = 3000m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/hunter.png",
                TeamId = listOfTeams[2].TeamId,
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "jks",
                FirstName = "Justin",
                LastName = "Savage",
                Bio = "third one of the team",
                Email = "jks@g2.com",
                MonthlySalary = 2000m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/jks.png",
                TeamId = listOfTeams[2].TeamId,
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "HooXi",
                FirstName = "Rasmus",
                LastName = "Nielsen",
                Bio = "fourth one of the team",
                Email = "hooxi@g2.com",
                MonthlySalary = 3000m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/hooxi.png",
                TeamId = listOfTeams[2].TeamId,
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "m0NESY",
                FirstName = "Ilya",
                LastName = "Osipov",
                Bio = "fifth one of the team",
                Email = "monesy@g2.com",
                MonthlySalary = 6700m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/m0nesy.png",
                TeamId = listOfTeams[2].TeamId,
            },
            // ===================================
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "pashaBiceps",
                FirstName = "Jaroslaw",
                LastName = "Jarzabkowski",
                Bio = "[CAPTAIN] ingame leader",
                Email = "biceps@vp.com",
                MonthlySalary = 5400m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/pashabiceps.png",
                TeamId = listOfTeams[3].TeamId,
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "FL1T",
                FirstName = "Evgenii",
                LastName = "Lebedev",
                Bio = "second one of the team",
                Email = "flit@vp.com",
                MonthlySalary = 3000m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/fl1t.png",
                TeamId = listOfTeams[3].TeamId,
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "Qikert",
                FirstName = "Alexey",
                LastName = "Golubev",
                Bio = "third one of the team",
                Email = "qikert@vp.com",
                MonthlySalary = 2000m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/qikert.png",
                TeamId = listOfTeams[3].TeamId,
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "Jame",
                FirstName = "Dzhami",
                LastName = "Ali",
                Bio = "fourth one of the team",
                Email = "jame@vp.com",
                MonthlySalary = 3000m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/jame.png",
                TeamId = listOfTeams[3].TeamId,
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "fame",
                FirstName = "Petr",
                LastName = "Bolyshev",
                Bio = "fifth one of the team",
                Email = "fame@vp.com",
                MonthlySalary = 6700m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/fame.png",
                TeamId = listOfTeams[3].TeamId,
            },
            // ===================================
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "KRIMZ",
                FirstName = "Freddy",
                LastName = "Johansson",
                Bio = "[CAPTAIN] ingame leader",
                Email = "krimz@fnatic.com",
                MonthlySalary = 5400m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/krimz.png",
                TeamId = listOfTeams[4].TeamId,
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "FASHR",
                FirstName = "Dion",
                LastName = "Derksen",
                Bio = "second one of the team",
                Email = "fashr@fnatic.com",
                MonthlySalary = 3000m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/fashr.png",
                TeamId = listOfTeams[4].TeamId,
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "nicoodoz",
                FirstName = "Nico",
                LastName = "Tamjidi",
                Bio = "third one of the team",
                Email = "nicoo@fnatic.com",
                MonthlySalary = 2000m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/nicoodoz.png",
                TeamId = listOfTeams[4].TeamId,
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "roeJ",
                FirstName = "Fredrik",
                LastName = "Jorgensen",
                Bio = "fourth one of the team",
                Email = "roej@fnatic.com",
                MonthlySalary = 3000m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/roej.png",
                TeamId = listOfTeams[4].TeamId,
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "mezii",
                FirstName = "William",
                LastName = "Merriman",
                Bio = "fifth one of the team",
                Email = "mezii@fnatic.com",
                MonthlySalary = 6700m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/mezii.png",
                TeamId = listOfTeams[4].TeamId,
            },
            // ===================================
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "niko",
                FirstName = "Nikolaj",
                LastName = "Kristensen",
                Bio = "[CAPTAIN] ingame leader",
                Email = "niko@og.com",
                MonthlySalary = 5400m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/niko-1.png",
                TeamId = listOfTeams[5].TeamId,
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "NEOFRAG",
                FirstName = "Adam",
                LastName = "Zouhar",
                Bio = "second one of the team",
                Email = "neofrag@og.com",
                MonthlySalary = 3000m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/neofrag.png",
                TeamId = listOfTeams[5].TeamId,
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "flameZ",
                FirstName = "Shahar",
                LastName = "Shushan",
                Bio = "third one of the team",
                Email = "flamez@og.com",
                MonthlySalary = 2000m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/flamez.png",
                TeamId = listOfTeams[5].TeamId,
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "degster",
                FirstName = "Abdul",
                LastName = "Gasanov",
                Bio = "fourth one of the team",
                Email = "degster@og.com",
                MonthlySalary = 3000m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/degster.png",
                TeamId = listOfTeams[5].TeamId,
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "F1KU",
                FirstName = "Maciej",
                LastName = "Miklas",
                Bio = "fifth one of the team",
                Email = "fiku@og.com",
                MonthlySalary = 6700m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/f1ku.png",
                TeamId = listOfTeams[5].TeamId,
            },
            // ===================================
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "cadiaN",
                FirstName = "Casper",
                LastName = "Moller",
                Bio = "[CAPTAIN] ingame leader",
                Email = "cadian@heroic.com",
                MonthlySalary = 5400m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/cadian.png",
                TeamId = listOfTeams[6].TeamId,
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "stavn",
                FirstName = "Martin",
                LastName = "Lund",
                Bio = "second one of the team",
                Email = "stavn@heroic.com",
                MonthlySalary = 3000m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/stavn.png",
                TeamId = listOfTeams[6].TeamId,
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "TeSeS",
                FirstName = "René",
                LastName = "Madsen",
                Bio = "third one of the team",
                Email = "teses@heroic.com",
                MonthlySalary = 2000m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/teses.png",
                TeamId = listOfTeams[6].TeamId,
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "sjuush",
                FirstName = "Rasmus",
                LastName = "Beck",
                Bio = "fourth one of the team",
                Email = "sjuush@heroic.com",
                MonthlySalary = 3000m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/sjuush.png",
                TeamId = listOfTeams[6].TeamId,
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "jabbi",
                FirstName = "Jakob",
                LastName = "Nygaard",
                Bio = "fifth one of the team",
                Email = "jabbi@heroic.com",
                MonthlySalary = 6700m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/jabbi.png",
                TeamId = listOfTeams[6].TeamId,
            },
            // ===================================
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "arT",
                FirstName = "Andrei",
                LastName = "Piovezan",
                Bio = "[CAPTAIN] ingame leader",
                Email = "art@furia.com",
                MonthlySalary = 5400m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/art.png",
                TeamId = listOfTeams[7].TeamId,
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "yuurih",
                FirstName = "Yuri",
                LastName = "Santos",
                Bio = "second one of the team",
                Email = "yuurih@furia.com",
                MonthlySalary = 3000m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/yuurih.png",
                TeamId = listOfTeams[7].TeamId,
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "KSCERATO",
                FirstName = "Kaike",
                LastName = "Cerato",
                Bio = "third one of the team",
                Email = "kscerato@furia.com",
                MonthlySalary = 2000m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/kscerato.png",
                TeamId = listOfTeams[7].TeamId,
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "saffee",
                FirstName = "Rafael",
                LastName = "Costa",
                Bio = "fourth one of the team",
                Email = "saffee@furia.com",
                MonthlySalary = 3000m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/saffee.png",
                TeamId = listOfTeams[7].TeamId,
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "drop",
                FirstName = "André",
                LastName = "Abreu",
                Bio = "fifth one of the team",
                Email = "drop@furia.com",
                MonthlySalary = 6700m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/drop-1.png",
                TeamId = listOfTeams[7].TeamId,
            },
            // ===================================
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "dexter",
                FirstName = "Christopher",
                LastName = "Nong",
                Bio = "[CAPTAIN] ingame leader",
                Email = "dexter@mouz.com",
                MonthlySalary = 5400m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/dexter.png",
                TeamId = listOfTeams[8].TeamId,
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "frozen",
                FirstName = "David",
                LastName = "Cernansky",
                Bio = "second one of the team",
                Email = "frozen@mouz.com",
                MonthlySalary = 3000m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/frozen.png",
                TeamId = listOfTeams[8].TeamId,
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "JDC",
                FirstName = "Jon",
                LastName = "de Castro",
                Bio = "third one of the team",
                Email = "jdc@mouz.com",
                MonthlySalary = 2000m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/jdc.png",
                TeamId = listOfTeams[8].TeamId,
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "torzsi",
                FirstName = "Adam",
                LastName = "Torzsas",
                Bio = "fourth one of the team",
                Email = "torzsi@mouz.com",
                MonthlySalary = 3000m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/torzsi.png",
                TeamId = listOfTeams[8].TeamId,
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "xertioN",
                FirstName = "Dorian",
                LastName = "Berman",
                Bio = "fifth one of the team",
                Email = "xertion@mouz.com",
                MonthlySalary = 6700m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/xertion.png",
                TeamId = listOfTeams[8].TeamId,
            },
            // ===================================
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "apEX",
                FirstName = "Dan",
                LastName = "Madesclaire",
                Bio = "[CAPTAIN] ingame leader",
                Email = "apex@vitality.com",
                MonthlySalary = 5400m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/apex.png",
                TeamId = listOfTeams[9].TeamId,
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "dupreeh",
                FirstName = "Peter",
                LastName = "Rasmussen",
                Bio = "second one of the team",
                Email = "dupreeh@vitality.com",
                MonthlySalary = 3000m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/dupreeh.png",
                TeamId = listOfTeams[9].TeamId,
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "Magisk",
                FirstName = "Emil",
                LastName = "Reif",
                Bio = "third one of the team",
                Email = "magisk@vitality.com",
                MonthlySalary = 2000m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/magisk.png",
                TeamId = listOfTeams[9].TeamId,
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "ZywOo",
                FirstName = "Mathieu",
                LastName = "Herbaut",
                Bio = "fourth one of the team",
                Email = "zywoo@vitality.com",
                MonthlySalary = 3000m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/zywoo.png",
                TeamId = listOfTeams[9].TeamId,
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "Spinx",
                FirstName = "Lotan",
                LastName = "Giladi",
                Bio = "fifth one of the team",
                Email = "spinx@vitality.com",
                MonthlySalary = 6700m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/spinx.png",
                TeamId = listOfTeams[9].TeamId,
            },
            // ===================================
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "Snappi",
                FirstName = "Marco",
                LastName = "Pfeiffer",
                Bio = "[CAPTAIN] ingame leader",
                Email = "snappi@ence.com",
                MonthlySalary = 5400m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/snappi.png",
                TeamId = listOfTeams[10].TeamId,
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "NertZ",
                FirstName = "Guy",
                LastName = "Iluz",
                Bio = "second one of the team",
                Email = "nertz@ence.com",
                MonthlySalary = 3000m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/nertz.png",
                TeamId = listOfTeams[10].TeamId,
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "Maden",
                FirstName = "Pavle",
                LastName = "Boskovic",
                Bio = "third one of the team",
                Email = "maden@ence.com",
                MonthlySalary = 2000m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/maden.png",
                TeamId = listOfTeams[10].TeamId,
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "dycha",
                FirstName = "Pawel",
                LastName = "Dycha",
                Bio = "fourth one of the team",
                Email = "dycha@ence.com",
                MonthlySalary = 3000m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/dycha.png",
                TeamId = listOfTeams[10].TeamId,
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "SunPayus",
                FirstName = "Alvaro",
                LastName = "Garcia",
                Bio = "fifth one of the team",
                Email = "sunpayus@ence.com",
                MonthlySalary = 6700m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/sunpayus.png",
                TeamId = listOfTeams[10].TeamId,
            },
            // ===================================
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "JT",
                FirstName = "Johny",
                LastName = "Theodosiou",
                Bio = "[CAPTAIN] ingame leader",
                Email = "jt@complexity.com",
                MonthlySalary = 5400m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/col-jt.png",
                TeamId = listOfTeams[11].TeamId,
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "floppy",
                FirstName = "Ricky",
                LastName = "Kemery",
                Bio = "second one of the team",
                Email = "floppy@complexity.com",
                MonthlySalary = 3000m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/floppy.png",
                TeamId = listOfTeams[11].TeamId,
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "hallzerk",
                FirstName = "Hakon",
                LastName = "Fjaerli",
                Bio = "third one of the team",
                Email = "hallzerk@complexity.com",
                MonthlySalary = 2000m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/hallzerk.png",
                TeamId = listOfTeams[11].TeamId,
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "Grim",
                FirstName = "Michael",
                LastName = "Wince",
                Bio = "fourth one of the team",
                Email = "grim@complexity.com",
                MonthlySalary = 3000m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/grim.png",
                TeamId = listOfTeams[11].TeamId,
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "FaNg",
                FirstName = "Justin",
                LastName = "Coakley",
                Bio = "fifth one of the team",
                Email = "fang@complexity.com",
                MonthlySalary = 6700m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/fang.png",
                TeamId = listOfTeams[11].TeamId,
            },
            // ===================================
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "k0nfig",
                FirstName = "Kristian",
                LastName = "Wienecke",
                Bio = "[CAPTAIN] ingame leader",
                Email = "konfig@nip.com",
                MonthlySalary = 5400m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/k0nfig.png",
                TeamId = listOfTeams[12].TeamId,
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "REZ",
                FirstName = "Fredrik",
                LastName = "Sterner",
                Bio = "second one of the team",
                Email = "rez@nip.com",
                MonthlySalary = 3000m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/rez.png",
                TeamId = listOfTeams[12].TeamId,
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "Aleksib",
                FirstName = "Aleksi",
                LastName = "Virolainen",
                Bio = "third one of the team",
                Email = "aleksib@nip.com",
                MonthlySalary = 2000m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/aleksib.png",
                TeamId = listOfTeams[12].TeamId,
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "Brollan",
                FirstName = "Ludvig",
                LastName = "Brolin",
                Bio = "fourth one of the team",
                Email = "brollan@nip.com",
                MonthlySalary = 3000m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/brollan.png",
                TeamId = listOfTeams[12].TeamId,
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "headtr1ck",
                FirstName = "Daniil",
                LastName = "Valitov",
                Bio = "fifth one of the team",
                Email = "headtrick@nip.com",
                MonthlySalary = 6700m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/headtr1ck.png",
                TeamId = listOfTeams[12].TeamId,
            },
            // ===================================
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "nitr0",
                FirstName = "Nick",
                LastName = "Cannella",
                Bio = "[CAPTAIN] ingame leader",
                Email = "nitro@liquid.com",
                MonthlySalary = 5400m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/nitr0.png",
                TeamId = listOfTeams[13].TeamId,
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "NAF",
                FirstName = "Keith",
                LastName = "Markovic",
                Bio = "second one of the team",
                Email = "naf@liquid.com",
                MonthlySalary = 3000m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/naf.png",
                TeamId = listOfTeams[13].TeamId,
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "EliGE",
                FirstName = "Jonathan",
                LastName = "Jablonowski",
                Bio = "third one of the team",
                Email = "elige@liquid.com",
                MonthlySalary = 2000m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/elige.png",
                TeamId = listOfTeams[13].TeamId,
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "oSee",
                FirstName = "Josh",
                LastName = "Ohm",
                Bio = "fourth one of the team",
                Email = "osee@liquid.com",
                MonthlySalary = 3000m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/osee.png",
                TeamId = listOfTeams[13].TeamId,
            },
            new Player
            {
                UserId = new Guid("C8CA7498-308D-489E-AED7-F284BB1D406B"),
                Nickname = "YEKINDAR",
                FirstName = "Mareks",
                LastName = "Galinskis",
                Bio = "fifth one of the team",
                Email = "yekindar@liquid.com",
                MonthlySalary = 6700m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/yekindar.png",
                TeamId = listOfTeams[13].TeamId,
            },
            // ===================================
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "NEKIZ",
                FirstName = "Gabriel",
                LastName = "Schenato",
                Bio = "[CAPTAIN] ingame leader",
                Email = "nekiz@pain.com",
                MonthlySalary = 5400m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/nekiz.png",
                TeamId = listOfTeams[14].TeamId,
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "hardzao",
                FirstName = "Wesley",
                LastName = "Lopes",
                Bio = "second one of the team",
                Email = "hardzao@pain.com",
                MonthlySalary = 3000m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/hardzao.png",
                TeamId = listOfTeams[14].TeamId,
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "biguzera",
                FirstName = "Rodrigo",
                LastName = "Bittencourt",
                Bio = "third one of the team",
                Email = "biguzera@pain.com",
                MonthlySalary = 2000m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/biguzera.png",
                TeamId = listOfTeams[14].TeamId,
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "skullz",
                FirstName = "Felipe",
                LastName = "Medeiros",
                Bio = "fourth one of the team",
                Email = "skullz@pain.com",
                MonthlySalary = 3000m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/skullz.png",
                TeamId = listOfTeams[14].TeamId,
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "zevy",
                FirstName = "Romeu",
                LastName = "Rocco",
                Bio = "fifth one of the team",
                Email = "zevy@pain.com",
                MonthlySalary = 6700m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/zevy.png",
                TeamId = listOfTeams[14].TeamId,
            },
            // ===================================
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "gla1ve",
                FirstName = "Lukas",
                LastName = "Rossander",
                Bio = "[CAPTAIN] ingame leader",
                Email = "glaive@astralis.com",
                MonthlySalary = 5400m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/gla1ve.png",
                TeamId = listOfTeams[15].TeamId,
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "device",
                FirstName = "Nicolai",
                LastName = "Reedtz",
                Bio = "second one of the team",
                Email = "device@astralis.com",
                MonthlySalary = 3000m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/dev1ce.png",
                TeamId = listOfTeams[15].TeamId,
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "blameF",
                FirstName = "Benjamin",
                LastName = "Bremer",
                Bio = "third one of the team",
                Email = "blamef@astralis.com",
                MonthlySalary = 7000m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/blamef.png",
                TeamId = listOfTeams[15].TeamId,
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "Altekz",
                FirstName = "Alexander",
                LastName = "Givskov",
                Bio = "fourth one of the team",
                Email = "altekz@astralis.com",
                MonthlySalary = 3000m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/altekz.png",
                TeamId = listOfTeams[15].TeamId,
            },
            new Player
            {
                UserId = Guid.NewGuid(),
                Nickname = "Buzz",
                FirstName = "Christian",
                LastName = "Andersen",
                Bio = "fifth one of the team",
                Email = "buzz@astralis.com",
                MonthlySalary = 6700m,
                AvatarUrl = "https://prosettings.net/wp-content/uploads/buzz-1.png",
                TeamId = listOfTeams[15].TeamId,
            },
        };

        listOfTourManagers = new List<TournamentManager>()
        {
            new TournamentManager
            {
                UserId = Guid.NewGuid(),
                FirstName = "Victor",
                LastName = "Goossens",
                Bio = "Founder of Blast.TV",
                Email = "nazgul@blast.com",
                AvatarUrl = "https://liquipedia.net/commons/images/thumb/d/df/Nazgul-Providence.jpg/600px-Nazgul-Providence.jpg",
                Nickname = "Nazgul",
                PasswordHash = "$2a$11$UHiAjLF0wJN53bCquEqnqOBrS8uQZ9MZzX0wj264IxZX/0tG12/FC"
            },
            new TournamentManager
            {
                UserId = Guid.NewGuid(),
                FirstName = "Konstantin",
                LastName = "Pikiner",
                Bio = "Founder of PGL",
                Email = "groove@pgl.com",
                AvatarUrl = "https://liquipedia.net/commons/images/thumb/6/6d/Groove_at_PGL_Major_Antwerp_2022.jpg/600px-Groove_at_PGL_Major_Antwerp_2022.jpg",
                Nickname = "groove",
                PasswordHash = "$2a$11$UHiAjLF0wJN53bCquEqnqOBrS8uQZ9MZzX0wj264IxZX/0tG12/FC"
            },
            new TournamentManager
            {
                UserId = Guid.NewGuid(),
                FirstName = "Tommy",
                LastName = "Ingemarsson",
                Bio = "Founder of ESL",
                Email = "potti@esl.com",
                AvatarUrl = "https://liquipedia.net/commons/images/thumb/2/2f/Potti_dhs2019.jpg/600px-Potti_dhs2019.jpg",
                Nickname = "Potti"
            }
        };

        listOfTournaments = new List<Tournament>()
        {
            new Tournament
            {
                TournamentId = Guid.NewGuid(),
                Title = "BLAST.tv Paris Major 2023",
                Location = "Paris, France",
                TournamentFormat = "16 Teams",
                MainSponsorName = "BLAST.tv",
                PrizeMoney = 1250000,
                StartDate = new DateTime(2023, 5, 8),
                EndDate = new DateTime(2023, 5, 21),
                TournamentManagerId = listOfTourManagers[0].UserId,
            },
            new Tournament
            {
                TournamentId = Guid.NewGuid(),
                Title = "BLAST.tv Dubai Major 2021",
                Location = "Dubai, United Arab Emirates",
                TournamentFormat = "16 Teams",
                MainSponsorName = "BLAST.tv",
                PrizeMoney = 1500000,
                StartDate = new DateTime(2021, 5, 8),
                EndDate = new DateTime(2021, 5, 21),
                TournamentManagerId = listOfTourManagers[0].UserId,
                WinningTeamId = listOfTeams[0].TeamId,
            },
            new Tournament
            {
                TournamentId = Guid.NewGuid(),
                Title = "PGL Major Antwerp 2022",
                Location = "Antwerp, Belgium",
                TournamentFormat = "16 Teams",
                MainSponsorName = "1XBET",
                PrizeMoney = 1000000,
                StartDate = new DateTime(2022, 5, 9),
                EndDate = new DateTime(2022, 5, 22),
                TournamentManagerId = listOfTourManagers[1].UserId,
                WinningTeamId = listOfTeams[1].TeamId,
            },
            new Tournament
            {
                TournamentId = Guid.NewGuid(),
                Title = "PGL CS2 Major Copenhagen 2024",
                Location = "Copenhagen, Denmark",
                TournamentFormat = "16 Teams",
                MainSponsorName = "HLTV",
                PrizeMoney = 1250000,
                StartDate = new DateTime(2024, 3, 17),
                EndDate = new DateTime(2024, 3, 31),
                TournamentManagerId = listOfTourManagers[1].UserId,
            },
            new Tournament
            {
                TournamentId = Guid.NewGuid(),
                Title = "ESL Pro League Season 17",
                Location = "Malta",
                TournamentFormat = "8 Teams",
                MainSponsorName = "CS.MONEY",
                PrizeMoney = 850000,
                StartDate = new DateTime(2023, 2, 22),
                EndDate = new DateTime(2023, 3, 26),
                TournamentManagerId = listOfTourManagers[2].UserId,
                WinningTeamId = listOfTeams[1].TeamId,
            },
            new Tournament
            {
                TournamentId = Guid.NewGuid(),
                Title = "ESL Premier World Final 2021",
                Location = "Copenhagen, Denmark",
                TournamentFormat = "8 Teams",
                MainSponsorName = "1XBET",
                PrizeMoney = 1000000,
                StartDate = new DateTime(2021, 12, 14),
                EndDate = new DateTime(2021, 12, 19),
                TournamentManagerId = listOfTourManagers[2].UserId,
                WinningTeamId = listOfTeams[0].TeamId,
            }
        };

        listOfArticles = new List<Article>()
        {
            new Article
            {
                ArticleId = Guid.NewGuid(),
                AuthorName = "Striker",
                Body = "After a mostly upset-less day two, the third day of play was a complete turnaround. ENCE, who were sent down to the 1-2 pool in Paris after a shock defeat to Into the Breach, were sent packing early on in the day following a resounding 0-2 loss to a well-playing Ninjas in Pyjamas.\r\n\r\nThe Nordic mix were in control for much of the fixture, handing the Marco \"⁠Snappi⁠\" Pfeiffer-led squad a 16-7 hounding on Mirage before wrapping things up with a 16-10 scoreline on Ancient to force the European roster to exit the Major in 12-14th place despite a flawless 3-0 run in the Challengers Stage.",
                CreationDate = DateTime.Now,
                PicUrl = "https://img-cdn.hltv.org/gallerypicture/7khd16wLnP5z8ohpLp5PZR.jpg?auto=compress&fm=avif&ixlib=java-2.1.0&m=%2Fm.png&mw=107&mx=20&my=474&q=75&w=800&s=f7b78f58b2fbeb02410f312b6732bd7b",
                Title = "Heavyweights in ENCE and G2 bow out",
                TeamId = listOfTeams[2].TeamId,
            },
            new Article
            {
                ArticleId = Guid.NewGuid(),
                AuthorName = "fazehat3r",
                Body = "FaZe had a disastrous start to their BLAST.tv Paris Major Legends stage campaign, dropping back-to-back best-on-ones to Heroic and, shockingly, Into the Breach to end up on the brink of elimination at the end of day one.\r\n\r\nThe European combine bounced back on day two with a best-of-three victory over 9INE, but were then matched against a familiar demon: Bad News Eagles.\r\n\r\nFlatron \"⁠juanflatroo⁠\" Halimi's side has twice played spoiler to FaZe, once at the IEM Rio Major in the 1-2 round to eliminate Finn \"⁠karrigan⁠\" Andersen's side from contention, and again at the BLAST.tv Paris Major Europe RMR, ultimately leading to FaZe getting cast down to the Last Chance Qualifier, where they only just managed to scrape through to make the Major.",
                CreationDate = DateTime.Now,
                PicUrl = "https://img-cdn.hltv.org/gallerypicture/mecDmr3C9bBh-5hysrymiq.jpg?auto=compress&fm=avif&ixlib=java-2.1.0&m=%2Fm.png&mw=107&mx=20&my=474&q=75&w=800&s=54a487de18e27c208a781ba0fd681103",
                Title = "karrigan: \"Beating Bad News Eagles now is slaying our demons\"",
                TeamId = listOfTeams[1].TeamId,
                PlayerId = listOfPlayers[5].UserId
            },
            new Article
            {
                ArticleId = Guid.NewGuid(),
                AuthorName = "heroiclover",
                Body = "After months of struggles to raise enough capital to continue operations, the Heroic Group is on the horizon of going private under a new owner.\r\n\r\nA key threshold of the sale has been met\r\n\r\nShareholders representing over 75% of all shares in Heroic Group have now signed purchase agreements with the to-be new owner, Krow Bidco AS, meeting the threshold necessary for the acquisition. The buyer is now expected to launch an offer for the acquisition of the remaining shares, according to the release.\r\n\r\nAccording to a Monday release on the Norwegian stock market, the Heroic Group has entered into an agreement for Krow Bidco AS to launch an offer to buy all outstanding shares of the company and recommended its shareholders to accept the offer.\r\n\r\nExpected to be completed in June, the offer stands at 2 NOK (~$0.19) per share, with the total value of all shares amounting to nearly 56 million NOK (~$5.2 million). Shareholders including the company's current board and management representing around 42% of all shares have already signed conditional purchase agreements, which will come into effect if the new buyer enters such agreements to acquire 75% of all outstanding shares.",
                CreationDate = DateTime.Now,
                Title = "While HEROIC compete in Paris, the company is in the process of being sold",
                PicUrl = "https://img-cdn.hltv.org/gallerypicture/b0rQLpG1HS76BQf3ZLtuHt.jpg?auto=compress&fm=avif&ixlib=java-2.1.0&m=%2Fm.png&mw=107&mx=20&my=474&q=75&w=800&s=8c809fb411d95b06a753b4eb974d4c72",
                TeamId = listOfTeams[6].TeamId,
                TournamentId = listOfTournaments[0].TournamentId
            },
            new Article
            {
                ArticleId = Guid.NewGuid(),
                AuthorName = "",
                Body = "Nikola \"⁠NiKo⁠\" Kovač landed in Paris as one of the best and most-storied players in CS:GO to never have won a Major title, and that is something that will never change. The Bosnian superstar has been eliminated from the BLAST.tv Paris Major in the Legends stage following a loss to fnatic in the 1-2 pool, cementing his name in the history books as the superstar who never took things over the line.\r\n\r\nHLTV spoke to NiKo after the heartbreaking loss, with the 26-year-old sharing his feelings on the early elimination and how he feels about never winning a CS:GO Major.",
                CreationDate = DateTime.Now,
                Title = "niko: \"I did not deserve to win a major in CS:GO\"",
                VidUrl = "https://youtu.be/9Odnx1UXqfE",
                PlayerId = new Guid("C356516D-97A7-45B2-9CE2-1646E12AB822"),
                TeamId = listOfTeams[2].TeamId,
                TournamentId = listOfTournaments[0].TournamentId
            },
            new Article
            {
                ArticleId = Guid.NewGuid(),
                AuthorName = "",
                Body = "\"We're not getting overconfident, but we have our own confidence to win games,\" YEKINDAR says.\r\n\r\nLiquid look like a team on a mission having gone up to the 2-0 pool in the first day of the BLAST.tv Paris Major's Legends Stage. From an 0-2 start in the Challengers Stage, the North American side is now just one best-of-three victory away from qualifying for the playoffs after taking out 9INE and Natus Vincere in two very convincing displays.\r\n\r\n\r\nYEKINDAR cheers as Liquid start their Legends Stage run with a clean 2-0\r\nAfter the perfect start in the Legends Stage, in which Liquid didn't give up double digits in either of their wins, Mareks \"⁠YEKINDAR⁠\" Gaļinskis — who dismantled NAVI with a 2.00 rating — took some time to answer questions about Liquid's clean start, their victory over Natus Vincere, and what it took to get the team rolling after a slow first day in the tournament's previous stage.",
                CreationDate = DateTime.Now,
                Title = "YEKINDAR: \"We always believed in ourselves, even when we started 0-2\"",
                PicUrl = "https://img-cdn.hltv.org/gallerypicture/LBIN66PWjmkN-aw3NtxH4z.jpg?auto=compress&fm=avif&ixlib=java-2.1.0&m=%2Fm.png&mw=107&mx=20&my=474&q=75&w=800&s=5961fe0b84c8a2996db7358c3d774f32",
                PlayerId = new Guid("C8CA7498-308D-489E-AED7-F284BB1D406B"),
                TeamId = listOfTeams[13].TeamId,
            },
            new Article
            {
                ArticleId = Guid.NewGuid(),
                Body = "FaZe are the sixth team to secure a spot in the BLAST.tv Paris Major 2023 playoffs after defeating Natus Vincere in the 2-2 decider match. The European squad successfully recovered from a catastrophic 0-2 start to the second group phase with three consecutive best-of-three victories to advance.\r\n\r\n\"We started to choke, we started to be nervous,\" said coach Andrey \"⁠B1ad3⁠\" Gorodenskiy in the post-match interview. \"People forgot what to do, threw another smoke, or forgot their roles... that's very important because when you play against FaZe you have to play at the top of your concentration.\"\r\n\r\nThe loss put an end to Natus Vincere's journey at the last CS:GO Major after a disappointing run in the Legends Stage. Their journey was marked by defeats to Liquid and an 0-2 collapse against Monte, losses which sent the Ukrainian squad to the elimination series.\r\n\r\nRobert \"⁠RobbaN⁠\" Dahlström's men will finally breathe a sigh of relief after a tense run to the knockout stage. FaZe's qualification for the playoffs started with an 0-2 record against Heroic and Into the Breach on the first day, but successfully recovered with wins over 9INE and Bad News Eagles to go into the decider fixtures.\r\n\r\nMeanwhile, Natus Vincere were eliminated in the group stage of a Major for the fourth time in their Global Offensive history and the first since PGL Krakow 2017, when they were eliminated by fnatic with a 1-3 record.",
                CreationDate = DateTime.Now,
                Title = "FaZe eliminate NAVI and clinch Paris Major playoffs spot",
                PicUrl = "https://img-cdn.hltv.org/gallerypicture/67VLw_4vyllf4LBAHQIP-P.jpg?auto=compress&fm=avif&ixlib=java-2.1.0&m=%2Fm.png&mw=107&mx=20&my=474&q=75&w=800&s=e66211fd14e717bef31b796905a15938",
                TeamId = listOfTeams[1].TeamId
            },
            new Article
            {
                ArticleId = Guid.NewGuid(),
                Body = "The Dane briefly spoke to us after Ninjas in Pyjamas' elimination from the BLAST.tv Paris Major.\r\n\r\nNinjas in Pyjamas crumbled in their 2-2 qualifying match for the BLAST.tv Paris Major playoffs, conceding an 0-2 defeat to Apeks after letting slip an immense lead on Ancient. The European combine held a 14-3 lead on the map before a disastrous T-side effort allowed Damjan \"⁠kyxsan⁠\" Stoilkovski's side to comeback and secure victroy in overtime.\r\n\r\nKristian \"⁠k0nfig⁠\" Wienecke had a quick word with HLTV in the mixed zone to give some early thoughts on the loss, something which Ninjas in Pyjamas took some quick time to discuss before coming into the interview area.",
                CreationDate = DateTime.Now,
                Title = "k0nfig: \"We did not trust the players and only trusted the stratbook\"",
                PicUrl = "https://img-cdn.hltv.org/gallerypicture/AQob_mtyOnkT5Nc2eJ4uOx.jpg?auto=compress&fm=avif&ixlib=java-2.1.0&m=%2Fm.png&mw=107&mx=20&my=474&q=75&w=800&s=5b0fbb7f11e13d134da10f12ab77e9f7",
                PlayerId = listOfPlayers[60].UserId,
                TeamId = listOfTeams[12].TeamId
            },
            new Article
            {
                ArticleId = Guid.NewGuid(),
                Body = "Relive Håvard \"⁠rain⁠\" Nygaard's top moments from the PGL Major in Antwerp with our highlight movie following his MVP run.\r\n\r\nrain became a Major MVP by outgunning all of the young stars on the stacked FaZe at the PGL Major in Antwerp, ending with a 1.24 rating and an astonishing 1.47 impact rating as a kicker. It was in the grand final against Natus Vincere, where he got a 1.49 rating by taking over the server on Nuke with 30 frags that rain secured the hardware.\r\n\r\nThis is rain's first MVP award since the ECS Season 4 Finals in Cancun, Mexico, and the third in his career as the 27-year-old player put forth a vintage performance in Belgium to once again take home a medal for his individual prowess.\r\n\r\nWatch the two-minute highlight reel from the event put together by Ayush \"AwptiX\" Kumar featuring rain's top moments from FaZe's matches against Natus Vincere, Cloud9, Ninjas in Pyjamas and Copenhagen Flames.",
                CreationDate = new DateTime(2022, 5, 23),
                Title = "rain - MVP of PGL MAJOR ANTWERP",
                PicUrl = "https://img-cdn.hltv.org/gallerypicture/Fz2VB7mLF6NLkc6klhb2iZ.jpg?auto=compress&fm=avif&ixlib=java-2.1.0&m=%2Fm.png&mw=107&mx=20&my=473&q=75&w=800&s=498077fc8e9074ddd4fa2e2c173ca4ca",
                VidUrl = "https://youtu.be/m9JQ2HYu1VI",
                PlayerId = listOfPlayers[6].UserId
            },
            new Article
            {
                ArticleId = Guid.NewGuid(),
                Body = "FaZe become the first international lineup to win a Major, besting the holders Natus Vincere 2-0\r\n\r\nNatus Vincere crumble under the pressure, something no one expected to happen, and FaZe bring it home.\r\n\r\nFinn \"⁠karrigan⁠\" Andersen finally wins his Major, after years of heartbreak and near misses, and it took a monumental performance from Håvard \"⁠rain⁠\" Nygaard to get it done.\r\n\r\nOnce FaZe get themselves another buy, they get rain through secret and he finds a kill, throwing the Natus Vincere defence into chaos. Despite things coming down to a 2v1 for FaZe with both members on less than 20 health, they manage to close it out.\r\n\r\nThis gives FaZe a chance to break the economy but they can't find the round needed in the follow up, and thus Natus Vincere get a few weaker buys to drag themselves close.\r\n\r\nHOWEVER, a pacy upper execute with Tec-9s bears fruit for FaZe, once again relying on a monster play from rain to bring things home.",
                CreationDate = new DateTime(2022, 5, 22),
                Title = "FaZe defeat NaVi 2-0 to win PGL Major Antwerp",
                PicUrl = "https://img-cdn.hltv.org/gallerypicture/0aAYFwGGz_WqZcs089YBqV.jpg?auto=compress&fm=avif&ixlib=java-2.1.0&m=%2Fm.png&mw=107&mx=20&my=473&q=75&w=800&s=55a2e7aa2644b88ee60cbfd5bbffdef7",
                TeamId = listOfTeams[1].TeamId
            },
            new Article
            {
                ArticleId = Guid.NewGuid(),
                Body = "Enjoy some of the best highlights from Oleksandr \"⁠s1mple⁠\" Kostyliev's record-breaking MVP performance at the BLAST Premier World Final.\r\n\r\nThe BLAST Premier World Final saw Natus Vincere close the season with another title, pulling off a run from the first round of the lower bracket to maintain their dominance in the latter half of the year and enter the off-season as the undisputed best team in the world.\r\n\r\nAs usual, s1mple was the main man behind the CIS team's success as the BitSkins.com MVP of the tournament, earning his eighth award in NAVI's eighth title run in 2021 to break Nicolai \"⁠device⁠\" Reedtz's record for most medals earned over the course of a calendar year and match the Dane's 19 career MVPs.\r\n\r\nIt wouldn't be s1mple if he didn't pull off some jaw-dropping plays throughout the tournament, the best of which we compiled in a highlight video produced by Filip \"filq\" Szatkowski.",
                CreationDate = new DateTime(2021, 5, 22),
                Title = "s1mple - MVP of Blast Premier World Final",
                VidUrl = "https://youtu.be/Amid1ZqPtvg",
                PlayerId = listOfPlayers[0].UserId
            },
        };
        // ===========================================================
        // ===========================================================

        allLists.Teams = listOfTeams;
        allLists.Players = listOfPlayers;
        allLists.TeamManagers = listOfTeamManagers;
        allLists.TournamentManagers = listOfTourManagers;
        allLists.Tournaments = listOfTournaments;
        allLists.Articles = listOfArticles;

        return allLists;
    }
}
