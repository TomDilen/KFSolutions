using KFSolutionsModel;
using KFSrepository_EF6;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFSolutionsWPF.PDF
{
    public static class  PDFinvoice
    {

        private const string PATH_TO_INVOICES = @"accountancy\invoices\";

        //=============================================================================
        public static string Create(int aId_OrderOut , AppRepository<KfsContext> aAppDbRespository)
        {
           return Create(  aAppDbRespository.OrderOut.GetForInvoiceById(aId_OrderOut));
        }

        //=============================================================================
        public static string  Create(OrderOut aOrderOut)
        {
 
            return filename;



        }
    }
}
