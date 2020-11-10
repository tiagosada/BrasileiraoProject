// using System;
// using System.Linq;

// namespace Domain
// {
//     public class Player
//     {
//         public Guid Id { get; private set; } = Guid.NewGuid();
//         public string Name { get; private set; }

//         public int Goals { get; set; }
//         //public string Position { get; set; }

//         public Player(string name)
//         {
//             Name = name;
//             Id = Guid.NewGuid();
//         }
//         public void GiveGoal()
//         {
//             this.Goals++;
//         }
//         public bool ValidateName()
//         {
//              if (string.IsNullOrEmpty(this.Name))
//             {
//                 return false;
//             }
            
//             if (!Name.All(char.IsLetter))
//             {
//                 return false;
//             }
//             if (!Name.All(x => char.IsLetter(x) || char.IsWhiteSpace(x)))
//             {
//                 return false;
//             }
//             if (!char.IsUpper(Name[0]))
//             {
//                 return false;
//             }
//             return true;
            
//         }
//     }
// }