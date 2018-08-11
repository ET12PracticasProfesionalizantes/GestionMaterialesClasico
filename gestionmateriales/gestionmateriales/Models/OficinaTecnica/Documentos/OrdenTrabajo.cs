﻿using gestionmateriales.Models.OficinaTecnica.GestionMateriales;
using gestionmateriales.Models.OficinaTecnica.Tipos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace gestionmateriales.Models.OficinaTecnica.Documentos
{
    [Table("OrdenTrabajo")]
    public class OrdenTrabajo
    {
        [Key]
        [Required]
        public int idOrdenTrabajo { get; set; }

        [Required]
        public int numero { get; set; }

        [Required]
        [StringLength(70)]
        public string nombre { get; set; }

        [Required]
        public int idTurno { get; set; }

        public virtual Turno turno { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime fecha { get; set; }

        [Required]
        [NotMapped]
        public int idJefeSeccion { get; set; }

        [Required]
        public virtual Personal jefeSeccion { get; set; }

        [Required]
        [NotMapped]
        public int idResponsable { get; set; }

        [Required]
        public virtual Personal responsable { get; set; }

        public virtual ICollection<ItemOrdenTrabajo> itemsOT { get; set; }

        [Required]
        public bool hab { get; set; }

        /// <summary>
        /// Usuario que creo la entrada
        /// </summary>
        [StringLength(50)]
        public string CREATED_BY { get; set; }

        /// <summary>
        /// Fecha de creacion
        /// </summary>
        public DateTime CREATION_DATE { get; set; }

        /// <summary>
        /// Ip desde que se creo la entrada
        /// </summary>
        [StringLength(20)]
        public string CREATION_IP { get; set; }

        /// <summary>
        /// Ultimo usuario que modifico la entrada
        /// </summary>
        [StringLength(50)]
        public string LAST_UPDATED_BY { get; set; }

        /// <summary>
        /// Fecha de la ultima modificacion 
        /// </summary>
        public DateTime LAST_UPDATED_DATE { get; set; }

        /// <summary>
        /// Ultima Ip desde que se modifico la entrada
        /// </summary>
        [StringLength(20)]
        public string LAST_UPDATED_IP { get; set; }

        public OrdenTrabajo()
        {
            this.itemsOT = new HashSet<ItemOrdenTrabajo>();
            this.hab = true;
        }
    }
}