﻿using Empire.DataAccess.Data;
using Empire.DataAccess.Repository.IRepository;
using Empire.Utilities;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;

namespace Empire.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db, IConfiguration configuration)
        {
            _db = db;
            ApplicationUser = new ApplicationUserRepository(_db);
            ShoppingCart = new ShoppingCartRepository(_db);
            Category = new CategoryRepository(_db);
            Product = new ProductRepository(_db);
            ProductSize = new ProductSizeRepository(_db);
            OrderHeader = new OrderHeaderRepository(_db);
            OrderDetail = new OrderDetailRepository(_db);
            ProductImage = new ProductImageRepository(_db);
            EmailSender = new EmailSender(configuration);
        }

        public ICategoryRepository Category { get; private set; }

        public IProductRepository Product { get; private set; }

        public IProductSizeRepository ProductSize { get; private set; }

        public IShoppingCartRepository ShoppingCart { get; private set; }

        public IApplicationUserRepository ApplicationUser { get; private set; }

        public IOrderHeaderRepository OrderHeader { get; private set; }

        public IOrderDetailRepository OrderDetail { get; private set; }

        public IProductImageRepository ProductImage { get; private set; }

        public IEmailSender EmailSender { get; private set; }

        public async Task Save()
        {
            await _db.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
