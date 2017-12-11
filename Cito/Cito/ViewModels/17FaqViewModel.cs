namespace Cito.ViewModels
{
    using System.Collections.Generic;

    public class FaqViewModel : CitoViewModelBase
    {
        //public List<FaqPair> FaqList => new List<FaqPair>()
        //                                    {


        //                                        new FaqPair(""),
        //                                        new FaqPair("", "We wash it for real, and don't steal your stereo while we're at it"),
        //                                        new FaqPair("Elite package $39.99", "We wash your car, don't steal from you and even vacuum the inside and leave a little pine-scented thingy inside"),
        //                                        new FaqPair("Life, Universe, Everything", "42"),
        //                                    };

        public string Question1 => "Who are our Washers?";

        public string Answer1 => "Our washers are proffessionals, each approved by our strict standards";

        public string Question2 => "What are our packages?";

        public string Answer2 => "We offer three packages that you may choose from: Standard, Profesional and Elite.";



        public string Question3 => "Standard package $12.99";

        public string Answer3 => "Lorem ipsum dolor sit amet.";



        public string Question4 => "Professional package 24.99";

        public string Answer4 => "Lorem ipsum dolor sit amet.";



        public string Question5 => "Elite package $39.99";

        public string Answer5 => "Lorem ipsum dolor sit amet.";



        public string Question6 => "Lorem ipsum question sit amet";

        public string Answer6 => "Lorem ipsum dolor sit amet.";


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