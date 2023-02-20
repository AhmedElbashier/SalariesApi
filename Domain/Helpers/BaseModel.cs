using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalariesApi.Domain.Helpers
{
    public class BaseModel
    {
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public BaseModel()
        {
        }
    }
}