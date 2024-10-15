﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ACDS.RevBill.Shared.DataTransferObjects
{
    public class StreetUpdateDto
    {
        [Required(ErrorMessage = "Organisation Id is a required field.")]
        public int OrganisationId { get; init; }
        [Required(ErrorMessage = "Agency Id is a required field.")]
        public int AgencyId { get; init; }
        [Required(ErrorMessage = "Street is a required field.")]
        public string? StreetName { get; init; }

        [Required(ErrorMessage = "Description is a required field.")]
        public string? Description { get; set; }
        public int? WardId { get; set; }

        [Required(ErrorMessage = "Status is a required field.")]
        public bool Active { get; init; }

        [Required(ErrorMessage = "DateModified is a required field.")]
        public DateTime DateModified { get; init; }

        [Required(ErrorMessage = " ModifiedBy is a required field.")]
        public string? ModifiedBy { get; init; }
    }
}

