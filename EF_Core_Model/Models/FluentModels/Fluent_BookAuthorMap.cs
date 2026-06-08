using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EF_Core_Model.Models
{
    public class Fluent_BookAuthorMap
    {
        public int Book_Id { get; set; }

        public int Author_Id { get; set; }

        public Fluent_Book Book { get; set; }

        public Fluent_Author Author { get; set; }
    }
}
