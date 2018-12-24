/*************************************************************\
|
|  Tokenizer.cs started on 5/25 by Nicholas Fullerton
|
|  This class tokenizes and strips unwanted characters from
|  a SQL statement. 
| 
\**************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SQuilL {
   class Tokenizer {
      
      string text;      
      List<string> tokens;

      // Default and only constructor, packs linguistic units into a list:
      public Tokenizer(string statement) {
         text = statement;
         tokens = new List<string>();
         // Temporary array to hold strings, tokenizer:
         string[] temp = this.text.Split(new Char[] {',', '\n', ' '},
            StringSplitOptions.RemoveEmptyEntries);      
         // Remove extra whitespace and add tokens to list:
         foreach (string s in temp) {
            s.Trim();
            tokens.Add(s);
         }
      }     

      // Gets Tokenized List:
      public List<string> getTokens() {
         if (text != null && tokens != null)
            return tokens;
         else {
            MessageBox.Show("Tokenize Failed", "The tokenization of your SQL statement failed!");
            return null;              
         }
      }   
   }   
}
