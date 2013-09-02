var controls = (function() {


    function loadLoginForm(selector) {
        var templ = controller.getTemplate("login.html").then(function (data) {
            $(selector).html("");
            $(selector).append(data);
            $(selector).unbind();
            controller.attachHandlers(selector, "#error-console");
        });
    }

    function loadLoggedForm(selector) {
        var templ = controller.getTemplate("LoggedInTemplate.html").then(function (data) {
            $(selector).html("");
            $(selector).append(data);
            $(selector).unbind();
            controller.attachHandlers(selector, "#error-console");
        });
    }

    function visualizePostList(data, selector) {
        var dat = data;
        var temp = controller.getTemplate("postTemplate.html").then(function (template) {
            var templ = Mustache.compile(template);
            var htmlContent = $("<ul></ul>");
            for (var i = 0, len = dat.result.length; i < len; i++) {
                var liElement = $("<li></li>");
                var innerTempl = templ(dat.result[i]);
                liElement.append(innerTempl);
                htmlContent.append(liElement);
            }

            $(selector).html(htmlContent);
            $(selector).append('<a href="#/logged-in">Go Back</a>');
        });
    }

    function loadPostForm(selector) {
        var temp = controller.getTemplate("postFormTemplate.html").then(function (template) {
            $(selector).html("");
            $(selector).append(template);
            $(selector).unbind();
            controller.attachHandlers(selector, "#error-console");

            $(selector).append('<a href="#/logged-in">Go Back</a>');
        });
    }

    function visualizePostDetails(data, commentData, selector) {
        var temp = controller.getTemplate("postShortTemplate.html").then(function (template) {
            var templ = Mustache.compile(template);
            var htmlContent = $("<div></div>");
            var innerTempl = templ(data.result);
            htmlContent.append(innerTempl);
            var commentTemplate = controller.getTemplate("commentTemplate.html").then(function (commentTemplate) {
                var comTempl = Mustache.compile(commentTemplate);
                for (var i = 0, len = commentData.result.length; i < len; i++) {
                    var commentHtml = comTempl(commentData.result[i]);
                    htmlContent.append(commentHtml);
                }

                $(selector).html(htmlContent);
                $(selector).append('<a href="#/logged-in">Go Back</a>');
            });            
        });
    }

    function visualizeCommentForm(id, selector) {
        var temp = controller.getTemplate("commentFormTemplate.html").then(function (template) {
            $(selector).html("");
            $(selector).append(template);
            $("#create-comment-btn").attr("post-id", id);
            $(selector).unbind();
            controller.attachHandlers(selector, "#error-console");

            $(selector).append('<a href="#/logged-in">Go Back</a>');
        });
    }

    return {
        loadLoginForm: loadLoginForm,
        loadLoggedForm: loadLoggedForm,
        visualizePostList: visualizePostList,
        loadPostForm: loadPostForm,
        visualizePostDetails: visualizePostDetails,
        visualizeCommentForm: visualizeCommentForm
    }
})();