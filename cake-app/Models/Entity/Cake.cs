using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cake_app.Models.Entity
{
   // representasi tabel cakes yang ada di database
   [Table("cakes")]
   public class Cake
   {
      [Key]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      [Required]
      [Column("id")]
      public int? Id { get; set; }

      [Required]
      [Column("name")]
      [MaxLength(255)]
      public string? Name { get; set; }

      [Required]
      [Column("price")]
      public int? Price { get; set; }

      [Column("description")]
      [MaxLength(500)]
      public string? Description { get; set; }
   }
}
