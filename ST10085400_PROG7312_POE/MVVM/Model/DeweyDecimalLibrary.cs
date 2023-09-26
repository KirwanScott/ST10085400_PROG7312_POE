using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10085400_PROG7312_POE.MVVM.Model
{
    public class DeweyDecimalLibrary
    {
        public class DeweyDecimalSystem
        {
            public List<DeweyClass> MainClasses { get; } = new List<DeweyClass>();

            public DeweyDecimalSystem()
            {
                InitializeMainClasses();
            }

            private void InitializeMainClasses()
            {
                // Main classes
                MainClasses.Add(new DeweyClass("000", "General Knowledge"));
                MainClasses.Add(new DeweyClass("100", "Philosophy & Psychology"));
                MainClasses.Add(new DeweyClass("200", "Religion"));
                MainClasses.Add(new DeweyClass("300", "Social Sciences"));
                MainClasses.Add(new DeweyClass("400", "Language"));
                MainClasses.Add(new DeweyClass("500", "Science"));
                MainClasses.Add(new DeweyClass("600", "Technology"));
                MainClasses.Add(new DeweyClass("700", "Arts & Recreation"));
                MainClasses.Add(new DeweyClass("800", "Literature"));
                MainClasses.Add(new DeweyClass("900", "History and Geography"));

                // Subclasses for "Generalities"
                MainClasses[0].Subclasses.Add(new DeweyClass("001", "Knowledge"));
                MainClasses[0].Subclasses.Add(new DeweyClass("002", "The book"));
                MainClasses[0].Subclasses.Add(new DeweyClass("003", "Systems"));
                MainClasses[0].Subclasses.Add(new DeweyClass("004", "Data processing"));
                MainClasses[0].Subclasses.Add(new DeweyClass("005", "Computer science"));
                MainClasses[0].Subclasses.Add(new DeweyClass("010", "Bibliography"));
                MainClasses[0].Subclasses.Add(new DeweyClass("020", "Library & Information Sciences"));
                MainClasses[0].Subclasses.Add(new DeweyClass("030", "Encyclopedias & Books of Facts"));
                MainClasses[0].Subclasses.Add(new DeweyClass("040", "Collections, Collectibles & Collecting"));
                MainClasses[0].Subclasses.Add(new DeweyClass("050", "Magazines, Journals & Serials"));
                MainClasses[0].Subclasses.Add(new DeweyClass("060", "Associations, Organizations & Museology"));
                MainClasses[0].Subclasses.Add(new DeweyClass("070", "News Media, Journalism & Publishing"));
                MainClasses[0].Subclasses.Add(new DeweyClass("080", "General Collections"));
                MainClasses[0].Subclasses.Add(new DeweyClass("090", "Manuscripts & Rare Books"));

                MainClasses[1].Subclasses.Add(new DeweyClass("110", "Metaphysics"));
                MainClasses[1].Subclasses.Add(new DeweyClass("120", "Epistemology"));
                MainClasses[1].Subclasses.Add(new DeweyClass("130", "Ethics"));
                MainClasses[1].Subclasses.Add(new DeweyClass("140", "Philosophical Systems & Schools"));
                MainClasses[1].Subclasses.Add(new DeweyClass("150", "Psychology"));
                MainClasses[1].Subclasses.Add(new DeweyClass("160", "Logic"));
                MainClasses[1].Subclasses.Add(new DeweyClass("170", "Ethical Philosophy"));
                MainClasses[1].Subclasses.Add(new DeweyClass("180", "Ancient, Medieval, & Eastern Philosophy"));
                MainClasses[1].Subclasses.Add(new DeweyClass("190", "Modern Western Philosophy"));

            }
        }

        public class DeweyClass
        {
            public string Code { get; }
            public string Description { get; }
            public List<DeweyClass> Subclasses { get; } = new List<DeweyClass>();

            public DeweyClass(string code, string description)
            {
                Code = code;
                Description = description;
            }
        }
    }
}
