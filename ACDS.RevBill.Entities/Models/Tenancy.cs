﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACDS.RevBill.Entities.Models
{
	public class Tenancy
	{
		[Key]
		public int Id { get; set; }
        [ForeignKey("Organisation")]
        public int OrganisationId { get; set; }
        public string? TenantId { get; set; }
        public string? ConnectionString { get; set; }
        public DateTime DateCreated { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public string? ModifiedBy { get; set; }

        public Organisation? Organisation { get; set; }
    }
}