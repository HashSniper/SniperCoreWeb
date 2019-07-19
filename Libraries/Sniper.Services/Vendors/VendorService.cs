using System;
using System.Collections.Generic;
using System.Text;
using Sniper.Core;
using Sniper.Core.Data;
using Sniper.Core.Domain.Vendors;
using Sniper.Services.Events;

namespace Sniper.Services.Vendors
{
    public partial class VendorService : IVendorService
    {
        #region Fields

        private readonly IEventPublisher _eventPublisher;
        private readonly IRepository<Vendor> _vendorRepository;
        private readonly IRepository<VendorNote> _vendorNoteRepository;

        #endregion

        #region Ctor

        public VendorService(IEventPublisher eventPublisher,
            IRepository<Vendor> vendorRepository,
            IRepository<VendorNote> vendorNoteRepository)
        {
            _eventPublisher = eventPublisher;
            _vendorRepository = vendorRepository;
            _vendorNoteRepository = vendorNoteRepository;
        }

        #endregion

        #region Methods
        public void DeleteVendor(Vendor vendor)
        {
            throw new NotImplementedException();
        }

        public void DeleteVendorNote(VendorNote vendorNote)
        {
            throw new NotImplementedException();
        }

        public string FormatVendorNoteText(VendorNote vendorNote)
        {
            throw new NotImplementedException();
        }

        public IPagedList<Vendor> GetAllVendors(string name = "", int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false)
        {
            throw new NotImplementedException();
        }

        public Vendor GetVendorById(int vendorId)
        {
            throw new NotImplementedException();
        }

        public VendorNote GetVendorNoteById(int vendorNoteId)
        {
            throw new NotImplementedException();
        }

        public IList<Vendor> GetVendorsByIds(int[] vendorIds)
        {
            throw new NotImplementedException();
        }

        public void InsertVendor(Vendor vendor)
        {
            throw new NotImplementedException();
        }

        public void UpdateVendor(Vendor vendor)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
