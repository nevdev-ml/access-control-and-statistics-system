﻿using Domain.Core.Logs;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Core
{
    /// <summary>
    /// Represents a event entity.
    /// </summary>
    [Auditable(AuditScope.ClassAndProperties)]
    public class Activity : IDescribable
    {
        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the user GUID.
        /// </summary>
        [Required]
        public string IdentityGUID { get; set; }

        /// <summary>
        /// Gets or sets the checkpoint IP-address.
        /// </summary>
        [Required]
        public string CheckpointIP { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the event status. True equals success and false equals failure.
        /// </summary>
        [Required]
        public bool? Status { get; set; }

        /// <summary>
        /// Gets or sets the event mode.
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Mode { get; set; }

        /// <summary>
        /// Implements <see cref="IDescribable.Describe()"/>
        /// </summary>
        public string Describe()
        {
            dynamic json = new JObject();
            json.ID = ID;
            json.IdentityGUID = IdentityGUID;
            json.CheckpointIP = CheckpointIP;
            json.Date = Date;
            json.Status = Status;
            json.Mode = Mode;
            return json.ToString();
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            var result = false;
            if (obj is Activity item)
            {
                result = ID == item.ID;
                result &= IdentityGUID.Equals(item.IdentityGUID);
                result &= CheckpointIP.Equals(item.CheckpointIP);
                result &= Date.Equals(item.Date);
                result &= Status.Equals(item.Status);
                result &= Mode.Equals(item.Mode);
                return result;
            }
            return false;
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            var hashcode = ID.GetHashCode();
            hashcode ^= IdentityGUID.GetHashCode();
            hashcode ^= CheckpointIP.GetHashCode();
            hashcode ^= Date.GetHashCode();
            hashcode ^= Status.GetHashCode();
            hashcode ^= Mode.GetHashCode();
            return hashcode;
        }
    }
}
