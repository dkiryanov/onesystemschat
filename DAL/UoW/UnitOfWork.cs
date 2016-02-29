using System;
using DAL.Entities;
using DAL.Repositories.Implementations;

namespace DAL.UoW
{
    /// <summary>
    /// Implementation of the unit of work pattern.
    /// </summary>
    public sealed class UnitOfWork : IDisposable
    {
        private bool _disposed;
        private readonly ChatEDMContainer _context;

        private MessageRepository _messageRepository;
        private UserRepository _userRepository;

        public UnitOfWork()
        {
            _context = new ChatEDMContainer();
        }

        /// <summary>
        /// Gets message's repository.
        /// </summary>
        public MessageRepository Messages
        {
            get { return _messageRepository ?? (_messageRepository = new MessageRepository(_context)); }
        }

        /// <summary>
        /// Gets user's repository.
        /// </summary>
        public UserRepository Users
        {
            get { return _userRepository ?? (_userRepository = new UserRepository(_context)); }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }
    }
}
