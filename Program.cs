using System;
using System.Collections.Generic;

namespace SampleApp
{
    class Program
    {
        static NavigationItem Root;

        static void LoadNavigationItems()
        {
            Root = new NavigationItem
            {
                Label = "Root",
                Url = "http://sample.com",
                Children = new List<NavigationItem> 
                {
                    new NavigationItem {
                        Label = "Products",
                        Url = "/products",
                        Children = new List<NavigationItem>
                        {
                            new NavigationItem
                            {
                                Label = "Dish Soap",
                                Url = "/dish-soap",
                                Children = new List<NavigationItem>()    
                            },
                            new NavigationItem
                            {
                                Label = "Laundry Detergent",
                                Url = "/laundry-detergent",
                                Children = new List<NavigationItem>()    
                            },
                            new NavigationItem
                            {
                                Label = "Napkins",
                                Url = "/napkins",
                                Children = new List<NavigationItem>()    
                            }
                        }
                    },
                    new NavigationItem {
                        Label = "Locations",
                        Url = "/locations",
                        Children = new List<NavigationItem>
                        {
                            new NavigationItem
                            {
                                Label = "New York",
                                Url = "/new-york",
                                Children = new List<NavigationItem>
                                {
                                    new NavigationItem
                                    {
                                        Label = "Bronx",
                                        Url = "/bronx",
                                        Children = new List<NavigationItem>()
                                    },
                                    new NavigationItem
                                    {
                                        Label = "Manhattan",
                                        Url = "/manhattan",
                                        Children = new List<NavigationItem>()
                                    },
                                    new NavigationItem
                                    {
                                        Label = "Queens",
                                        Url = "/queens",
                                        Children = new List<NavigationItem>()
                                    }
                                }   
                            }
                        }
                    },
                    new NavigationItem {
                        Label = "Support",
                        Url = "/support",
                        Children = new List<NavigationItem>()
                    }
                }
            };
        }

        static string GenerateTabs(int count)
        {
            string tabs = "";
            
            for(int i = count; i > 0; i--)
            {
                tabs += '\t';
            }

            return tabs;
        }

        static string Load(NavigationItem navItem, int level = 0)
        {
            string output = "";

            // Don't display anything for the root label
            if(navItem.Label != "Root")
            {
                output += GenerateTabs(level) + navItem.Label + '\n';

                // Increment the indention level for the next loop
                level++;
            }

            // Recurse the rest of the navigation items
            foreach(NavigationItem child in navItem.Children)
            {
                output += Load(child, level);
            }

            // Return the output string
            return output;
        }

        static void Main(string[] args)
        {
            LoadNavigationItems();
            Console.WriteLine(Load(navItem: Root));
        }
    }

    public class NavigationItem
    {
        public string Label { get; set; }
        public string Url { get; set; }
        public List<NavigationItem> Children { get; set; }
    }
}
