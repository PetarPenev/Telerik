(function($){
    $.fn.treeview = function(){    
        var element = this;
        var links = element.find("a");
        links.on("click", function () {
            $(this).next("ul").toggle();
        });
    }
}(jQuery));