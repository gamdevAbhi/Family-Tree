namespace FamilyTree
{
    public class Run
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            
            // write your tree here
            Tree tree = new Tree(new Person("William Henry Thompson", Person.Gender.Male),
            new Person("Margaret Anne Thompson", Person.Gender.Female), new List<Tree>()
            {
                // Second Gen: Clara with male non-offspring spouse
                new Tree(new Person("Clara Thompson", Person.Gender.Female),
                    new Person("Edward James Harrison", Person.Gender.Male), new List<Tree>()
                    {
                        new Tree(new Person("Benjamin Harrison", Person.Gender.Male),
                            new Person("Sophie Elizabeth Carter", Person.Gender.Female), new List<Tree>()
                            {
                                new Tree(new Person("Lucas Harrison", Person.Gender.Male),
                                    new Person("Amelia Grace Foster", Person.Gender.Female), new List<Tree>()
                                    {
                                        new Tree(new Person("Charlotte Harrison", Person.Gender.Female)),
                                        new Tree(new Person("Ethan Harrison", Person.Gender.Male))
                                    }),
                                new Tree(new Person("Emma Harrison", Person.Gender.Female),
                                    new Person("Daniel Patrick Walsh", Person.Gender.Male), new List<Tree>()
                                    {
                                        new Tree(new Person("Jacob Walsh", Person.Gender.Male)),
                                        new Tree(new Person("Olivia Walsh", Person.Gender.Female)),
                                        new Tree(new Person("Ava Walsh", Person.Gender.Female))
                                    })
                            }),
                        new Tree(new Person("Lillian Harrison", Person.Gender.Female),
                            new Person("Thomas Andrew Brooks", Person.Gender.Male), new List<Tree>()
                            {
                                new Tree(new Person("Isabella Brooks", Person.Gender.Female)),
                                new Tree(new Person("Henry Brooks", Person.Gender.Male),
                                    new Person("Evelyn Rose Parker", Person.Gender.Female), new List<Tree>()
                                    {
                                        new Tree(new Person("Sophia Brooks", Person.Gender.Female)),
                                        new Tree(new Person("James Brooks", Person.Gender.Male))
                                    })
                            }),
                        new Tree(new Person("Nathaniel Harrison", Person.Gender.Male)) // Single
                    }),
                // Second Gen: Charles with complex family
                new Tree(new Person("Charles Thompson", Person.Gender.Male),
                    new Person("Dorothy Marie Evans", Person.Gender.Female), new List<Tree>()
                    {
                        new Tree(new Person("Alexander Thompson", Person.Gender.Male),
                            new Person("Grace Eleanor Reed", Person.Gender.Female), new List<Tree>()
                            {
                                new Tree(new Person("Samuel Thompson", Person.Gender.Male),
                                    new Person("Hannah Claire Morgan", Person.Gender.Female), new List<Tree>()
                                    {
                                        new Tree(new Person("Lily Thompson", Person.Gender.Female)),
                                        new Tree(new Person("Michael Thompson", Person.Gender.Male))
                                    }),
                                new Tree(new Person("Abigail Thompson", Person.Gender.Female)) // Single
                            }),
                        new Tree(new Person("Victoria Thompson", Person.Gender.Female),
                            new Person("Robert Joseph Lane", Person.Gender.Male), new List<Tree>()
                            {
                                new Tree(new Person("Chloe Lane", Person.Gender.Female),
                                    new Person("Matthew David Perry", Person.Gender.Male), new List<Tree>()
                                    {
                                        new Tree(new Person("Zoe Perry", Person.Gender.Female)),
                                        new Tree(new Person("Benjamin Perry", Person.Gender.Male))
                                    }),
                                new Tree(new Person("William Lane", Person.Gender.Male)) // Single
                            }),
                        new Tree(new Person("George Thompson", Person.Gender.Male),
                            new Person("Nancy Ellen Wright", Person.Gender.Female), new List<Tree>()
                            {
                                new Tree(new Person("David Thompson", Person.Gender.Male)),
                                new Tree(new Person("Ella Thompson", Person.Gender.Female))
                            })
                    }),
                // Second Gen: Single daughter
                new Tree(new Person("Edith Thompson", Person.Gender.Female),
                    new Person("Frank Michael Collins", Person.Gender.Male), new List<Tree>()
                    {
                        new Tree(new Person("Rose Collins", Person.Gender.Female),
                            new Person("Philip Steven Turner", Person.Gender.Male), new List<Tree>()
                            {
                                new Tree(new Person("Harry Turner", Person.Gender.Male),
                                    new Person("Laura Jane Fisher", Person.Gender.Female), new List<Tree>()
                                    {
                                        new Tree(new Person("Jack Turner", Person.Gender.Male)),
                                        new Tree(new Person("Mia Turner", Person.Gender.Female))
                                    }),
                                new Tree(new Person("Violet Collins", Person.Gender.Female)) // Single
                            }),
                        new Tree(new Person("Arthur Collins", Person.Gender.Male)) // Single
                    }),
                // Second Gen: Remarriage case
                new Tree(new Person("Frederick Thompson", Person.Gender.Male),
                    new Person("Helen Louise Baker", Person.Gender.Female), new List<Tree>()
                    {
                        new Tree(new Person("Joseph Thompson", Person.Gender.Male),
                            new Person("Sarah Catherine Hayes", Person.Gender.Female), new List<Tree>()
                            {
                                new Tree(new Person("Oliver Thompson", Person.Gender.Male)),
                                new Tree(new Person("Emily Thompson", Person.Gender.Female),
                                    new Person("Christopher Lee Stone", Person.Gender.Male), new List<Tree>()
                                    {
                                        new Tree(new Person("Avery Stone", Person.Gender.Female))
                                    })
                            })
                    }),
                new Tree(new Person("Frederick Thompson", Person.Gender.Male), // Remarriage
                    new Person("Martha Beatrice Kelly", Person.Gender.Female), new List<Tree>()
                    {
                        new Tree(new Person("Alice Thompson", Person.Gender.Female),
                            new Person("John Edward Riley", Person.Gender.Male), new List<Tree>()
                            {
                                new Tree(new Person("Noah Riley", Person.Gender.Male)),
                                new Tree(new Person("Ruby Riley", Person.Gender.Female))
                            })
                    })
            });

            ApplicationConfiguration.Initialize();
            Application.Run(new FamilyTree(tree, 0.8f));
        }
    }
}