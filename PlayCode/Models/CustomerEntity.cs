using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Storage.Table;

namespace PlayCode.Models
{
    public class CustomerEntity: TableEntity
    {
        public CustomerEntity(Guid employeeId)
        {
            PartitionKey = "customer";
            RowKey = employeeId.ToString();
        }

        public CustomerEntity()
        {
            
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}