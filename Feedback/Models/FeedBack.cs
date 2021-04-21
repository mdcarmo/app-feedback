using System;
using System.Collections.Generic;
using System.Text;

namespace Feedback.Models
{
    public class FeedBack
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public DateTime RegisterDate { get; set; }
        public FeedBackType Type { get; set; }
        public string BoxColor { get; set; }
    }

    public enum FeedBackType
    {
        Positivo,
        Negativo,
        Construtivo,
        Pessoal
    }
}
