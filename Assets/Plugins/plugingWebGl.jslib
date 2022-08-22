var OpenWindowPlugin = {
    openWindow: function(link)
    {
    	var url = Pointer_stringify(link);
		window.location.href=url;     
    }
};

mergeInto(LibraryManager.library, OpenWindowPlugin);