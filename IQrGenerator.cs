using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QrLib
{
    public interface IQrGenerator
    {
        /// <summary>
        /// Generate a QR Code from raw text
        /// </summary>
        /// <param name="text">The QR code raw text</param>
        /// <returns>A byte array containing the image data of the QR Code (Header + data!)</returns>
        public byte[] FromText(string text);

        /// <summary>
        /// Generate a QR Code from a phone number
        /// </summary>
        /// <param name="phoneNumber">A valid phone number</param>
        /// <returns>A byte array containing the image data of the QR Code (Header + data!)</returns>
        public byte[] FromPhone(string phoneNumber);

        /// <summary>
        /// Generate a QR Code that sends an email
        /// </summary>
        /// <param name="mailReceiver">The email receiver</param>
        /// <param name="subject">The email subject</param>
        /// <param name="content">The email content, either text or html</param>
        /// <returns>A byte array containing the image data of the QR Code (Header + data!)</returns>
        public byte[] FromMail(string mailReceiver, string subject, string content);

        /// <summary>
        /// Generate a QR Code from an object by calling its 
        /// ToString() method, honestly you don't even need to code this one, it's just to show templating
        /// </summary>
        /// <typeparam name="T">The object type</typeparam>
        /// <param name="obj">The object</param>
        /// <returns>A byte array containing the image data of the QR Code (Header + data!)</returns>
        public byte[] FromObject<T>(T obj);
    }
}