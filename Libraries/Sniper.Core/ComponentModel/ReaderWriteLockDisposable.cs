using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Sniper.Core.ComponentModel
{
    public class ReaderWriteLockDisposable : IDisposable
    {
        private readonly ReaderWriterLockSlim _rwLock;
        private readonly ReaderWriteLokeType _readerWriteLockType;


        public ReaderWriteLockDisposable(ReaderWriterLockSlim rwLock, ReaderWriteLokeType readerWriteLokeType = ReaderWriteLokeType.Write)
        {
            _rwLock = rwLock;
            _readerWriteLockType = readerWriteLokeType;

            switch (_readerWriteLockType)
            {
                case ReaderWriteLokeType.Read:
                    _rwLock.EnterReadLock();
                    break;
                case ReaderWriteLokeType.Write:
                    _rwLock.EnterWriteLock();
                    break;
                case ReaderWriteLokeType.UpgradeableRead:
                    _rwLock.EnterUpgradeableReadLock();
                    break;
            }
        }

        public void Dispose()
        {
            switch (_readerWriteLockType)
            {
                case ReaderWriteLokeType.Read:
                    _rwLock.ExitReadLock();
                    break;
                case ReaderWriteLokeType.Write:
                    _rwLock.ExitWriteLock();
                    break;
                case ReaderWriteLokeType.UpgradeableRead:
                    _rwLock.ExitUpgradeableReadLock();
                    break;
            }
        }
    }
}
