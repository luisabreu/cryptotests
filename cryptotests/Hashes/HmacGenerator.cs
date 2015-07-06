using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace cryptotests.Hashes
{
    public class HmacGenerator:IHmacGenerator, IDisposable  {
        private readonly HMAC _hmacGenerator;

        public HmacGenerator(HMAC hmacGenerator) {
            if (hmacGenerator == null) {
                throw new ArgumentNullException($"{nameof(hmacGenerator)} cannot be null.");
            }
            _hmacGenerator = hmacGenerator;
        }

        public byte[] ComputeHmac(byte[] msgToHash) {
            return _hmacGenerator.ComputeHash(msgToHash);
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected  virtual void Dispose(bool isDisposing)
        {
            if (isDisposing) {
                _hmacGenerator.Dispose();
            }
        }
    }

    
}
