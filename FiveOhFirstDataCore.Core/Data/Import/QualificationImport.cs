﻿using System;
using System.IO;
using System.Threading.Tasks;

namespace FiveOhFirstDataCore.Core.Data.Import
{
    public class QualificationImport : IDisposable, IAsyncDisposable
    {
        private bool disposedValue;

        public FileStream? UnifiedQualStream { get; set; }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    UnifiedQualStream?.Dispose();
                }

                UnifiedQualStream = null;

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual async ValueTask DisposeAsyncCore()
        {
            if (UnifiedQualStream is not null)
                await UnifiedQualStream.DisposeAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await DisposeAsyncCore();

            Dispose(false);
            GC.SuppressFinalize(this);
        }
    }
}
