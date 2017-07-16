using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TodoMVC.Models
{
    public class Todo
    {
        [Key]
        [Required]
        [DisplayName("ID")]
        public Guid Id { get; set; }

        [DisplayName("代辦事項")]
        [Required]
        [StringLength(255)]
        public string Content { get; set; }

        [DisplayName("完成")]
        public bool IsComplete { get; set; }

        [DisplayName("建立時間")]
        public DateTime? CreateTime { get; set; }

        public Todo()
        {
            Id = Guid.NewGuid();
            CreateTime = DateTime.Now;
        }
    }
}