// ***********************************************************************
// Assembly         : AnThinhPhat.Utilities
// Author           : tranthiencdsp@gmail.com
// Created          : 03-13-2016
//
// Last Modified By : tranthiencdsp@gmail.com
// Last Modified On : 02-18-2016
// ***********************************************************************
// <copyright file="MailAttachment.cs" company="Atmel Corporation">
//     Copyright © Atmel 2016
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.IO;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;

namespace AnThinhPhat.Utilities
{
    public class MailAttachment
    {
        /// <summary>
        ///     Construct a mail attachment form a byte array
        /// </summary>
        /// <param name="data">Bytes to attach as a file</param>
        /// <param name="filename">Logical filename for attachment</param>
        public MailAttachment(byte[] data, string filename)
        {
            Stream = new MemoryStream(data);
            Filename = filename;
            MediaType = MediaTypeNames.Application.Octet;
        }

        /// <summary>
        ///     Construct a mail attachment from a string
        /// </summary>
        /// <param name="data">String to attach as a file</param>
        /// <param name="filename">Logical filename for attachment</param>
        public MailAttachment(string data, string filename)
        {
            Stream = new MemoryStream(Encoding.ASCII.GetBytes(data));
            Filename = filename;
            MediaType = MediaTypeNames.Text.Html;
        }

        /// <summary>
        ///     The data memory stream to use
        /// </summary>
        public MemoryStream Stream { get; set; }

        /// <summary>
        ///     Gets the original filename for this attachment
        /// </summary>
        public string Filename { get; set; }

        /// <summary>
        ///     Gets the attachment type: Bytes or String
        /// </summary>
        public string MediaType { get; set; }

        /// <summary>
        ///     Gets the file for this attachment (as a new attachment)
        /// </summary>
        public Attachment File
        {
            get { return new Attachment(Stream, Filename, MediaType); }
        }

        /// <summary>
        ///     Gets the length of this attachement data
        /// </summary>
        public double Size
        {
            get { return Stream.Length; }
        }
    }
}