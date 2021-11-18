namespace BreakingBad.API.Models.Entities
{
    public class Occupation
    {
        private string[] occupation;

        public Occupation(string[] occupation)
        {
            this.occupation = occupation;
            occupation = new string[]
            {
                "High School Chemistry Teacher",
                "Meth King Pin",
                "Meth Dealer",
                "House wife",
                "Book Keeper",
                "Car Wash Manager",
                "Taxi Dispatcher",
                "DEA Agent",
                "Lawyer",
                "Clepto",
                "Hitman",
                "Private Investigator",
                "Ex-Cop"
            };
        }
    }
}