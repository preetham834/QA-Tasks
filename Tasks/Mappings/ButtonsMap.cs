using Microsoft.Playwright;
using NUnit;
namespace buttonnnss;
public class ButtonMap
{
    public static Dictionary<String,String> buttons=new()
    {
        {"submit","#submit"},
        {"dbclick","#doubleClickBtn"},
        {"rightclick","#rightClickBtn"},
        {"singleclick",".btn.btn-primary"},
        {"Doubleclick","#doubleClickMessage"},
        {"Rightclick","#rightClickMessage" },
        {"Singleclick","#dynamicClickMessage" },
        {"add","#addNewRecordButton"},
        {"smallModal","#showSmallModal"},
        {"largeModal","#showLargeModal"},
        {"dialog","#alertButton"},
        {"confirm","#confirmButton"},
        {"Prompt","#promtButton"},
        {"expand",".rc-tree-switcher"},
        {"Home","[aria-label='Select Home']" },
        {"Desktop","[aria-label='Select Desktop']" },
        {"Documents","[aria-label='Select Documents']"},
        {"Downloads", "[aria-label='Select Downloads']"},
        {"Result","#result" },
        {"yes","#yesRadio" },
        {"impressive","#impressiveRadio"},
        {"no","#noRadio" },
        {"Text",".text-success"},
        {"newtab","#tabButton" },
        {"confirmresult","#confirmResult" },
        {"promptfield","#promptResult" },
        {"frame","#frame1" },
        {"frame1","#frame2" },
        {"childframe","iframe" },
        {"dialogcontent",".modal-body" },
        { "closesmallmodal","#closeSmallModal"},
        {"closelargemodal","#closeLargeModal" },
        {"upload","#uploadFile" },
        {"uploadedfilepath","#uploadedFilePath" },
        {"download","#downloadButton" },
        {"edit","[title='Edit']"},
        {"delete","[title='Delete']" }

    };
}