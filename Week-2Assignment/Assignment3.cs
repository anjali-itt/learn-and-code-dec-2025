//Assignment 3: CustomerSearch (LINQ + Clean Code)

using System;
using System.Collections.Generic;
using System.Text;

public class CustomerSearch
{
    private readonly DatabaseContext db;

    public CustomerSearch(DatabaseContext context)
    {
        db = context;
    }

    public List<Customer> SearchByCountry(string country)
    {
        return Search(c => c.Country.Contains(country));
    }

    public List<Customer> SearchByCompanyName(string companyName)
    {
        return Search(c => c.CompanyName.Contains(companyName));
    }

    public List<Customer> SearchByContact(string contactName)
    {
        return Search(c => c.ContactName.Contains(contactName));
    }

    private List<Customer> Search(Func<Customer, bool> predicate)
    {
        return db.Customers
                 .Where(predicate)
                 .OrderBy(c => c.CustomerID)
                 .ToList();
    }

    public string ExportToCsv(List<Customer> customers)
    {
        var sb = new StringBuilder();

        foreach (var customer in customers)
        {
            sb.AppendLine($"{customer.CustomerID},{customer.CompanyName},{customer.ContactName},{customer.Country}");
        }

        return sb.ToString();
    }
}
