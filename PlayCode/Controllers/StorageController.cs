using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.Table;
using PlayCode.Models;

namespace PlayCode.Controllers
{
    public class StorageController : Controller
    {
        // GET: Storage
        public ActionResult Index()
        {
            var storageConnectionStirng = ConfigurationManager.ConnectionStrings["StorageCon"].ConnectionString;

            var storageAccount = CloudStorageAccount.Parse(storageConnectionStirng);

            var tableClient = storageAccount.CreateCloudTableClient();

            var table = tableClient.GetTableReference("customer");

            table.CreateIfNotExists();

            var customer = new CustomerEntity(Guid.NewGuid())
            {
                FirstName = "Usman",
                LastName = "Ikram",
                Email = "usman.ikram@microtechx.org",
                PhoneNumber = "03215121621"

            };

            var insertOperation = TableOperation.Insert(customer);

            table.Execute(insertOperation);


            var queueClient = storageAccount.CreateCloudQueueClient();

            var queue = queueClient.GetQueueReference("customerqueue");

            queue.CreateIfNotExists();

            var message = new CloudQueueMessage(customer.RowKey);

            queue.AddMessage(message);
            return View(customer);
        }

        
    }

    
}