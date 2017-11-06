namespace Cito.ViewModels
{
    using System.Collections.Generic;

    public class FaqViewModel : CitoViewModelBase
    {
        public List<FaqPair> FaqList => new List<FaqPair>()
                                            {
                                                new FaqPair("Who are our Washers?", "Our washers are proffessionals, each approved by our strict standards"),
                                                new FaqPair("What are our packages?", "We offer four packages that you may choose from: Standard, Profesional and Elite."),
                                                new FaqPair("Standard package $12.99", "We wash your car with soap and water."),
                                                new FaqPair("Professional package 24.99", "We wash it for real, and don't steal your stereo while we're at it"),
                                                new FaqPair("Elite package $39.99", "We wash your car, don't steal from you and even vacuum the inside and leave a little pine-scented thingy inside"),
                                                new FaqPair("Life, Universe, Everything", "42"),
                                            }; 


        public struct FaqPair
        {
            public string Question { get; set; }
        
            public string Answer { get; set; }

            public FaqPair(string question, string answer)
            {
                this.Question = question;
                this.Answer = answer;
            }
        }
    }
}
