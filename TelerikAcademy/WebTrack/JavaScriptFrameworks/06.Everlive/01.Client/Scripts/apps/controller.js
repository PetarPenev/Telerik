var controller = (function(){

    function isLoggedIn() {
        var truth = localStorage.getItem("token") != null &&
            localStorage.getItem("token") != undefined;

        return truth;
    }

    function getTemplate(serviceUrl) {
        var promise = new RSVP.Promise(function (resolve, reject) {
            var templates = localStorage.getItem(serviceUrl);
            if (templates != undefined) {
                resolve(templates[serviceUrl]);
            }

            var path = "Scripts/templates/" + serviceUrl;
            $.get(path, function (data) { resolve(data) });
        });

        return promise;
    }

    function attachUIEventHandlers(selector, errSelector) {
        var wrapper = $(selector);
        var errContainer = $(errSelector);
        var self = this;

        wrapper.on("click", "#btn-show-login", function () {
            wrapper.find(".button.selected").removeClass("selected");
            $(this).addClass("selected");
            wrapper.find("#login-form").show();
            wrapper.find("#register-form").hide();
            event.stopPropagation();
        });
        wrapper.on("click", "#btn-show-register", function () {
            wrapper.find(".button.selected").removeClass("selected");
            $(this).addClass("selected");
            wrapper.find("#register-form").show();
            wrapper.find("#login-form").hide();
            event.stopPropagation();
        });

        wrapper.on("click", "#btn-login", function () {
            var user = {
                username: $(selector + " #tb-login-username").val(),
                password: $(selector + " #tb-login-password").val()
            }

            persister.login(user, function (data) {
                localStorage.setItem("token", data.result.access_token);
                window.location = "#/logged-in";
            },
            function (err) {
                errContainer.append("<p>Problem with login.</p>");
                errContainer.append("<p>" + err.message + "</p>");
            });

            return false;
        });

        wrapper.on("click", "#btn-register", function () {
            var user = {
                username: $(selector).find("#tb-register-username").val(),
                nickname: $(selector).find("#tb-register-nickname").val(),
                password: $(selector + " #tb-register-password").val(),
                email: $(selector + " #tb-register-email").val()
            }

            persister.register(user, function (data) {
                errContainer.append("<p>User created successfully. Please log in.</p>");
            }, function (err) {
                errContainer.append("<p>Problem with register.</p>");
                errContainer.append("<p>" + err.message + "</p>");
            });

            return false;
        });

        wrapper.on("click", "#btn-logout", function () {
            persister.logout(function (data) {
                localStorage.removeItem("token");
                window.location = "#/";
            }, function (err) {
                errContainer.append("<p>Problem with logout.</p>");
                errContainer.append("<p>" + err.message + "</p>");
            });
        });

        wrapper.on("click", "#posts-by-tags", function () {
            var tagValue = $("#input-tags").val();
            window.location = "#/posts/" + tagValue;
        });

        wrapper.on("click", "#create-post-btn", function () {
            var post = {
                title: $("#post-title-input").val(),
                content: $("#post-content-input").val(),
                tags: $("#post-tags-input").val()
            };

            persister.createPost(post, function (data) {
                errContainer.append("<p>Post successfully created.</p>");
            }, function (err) {
                errContainer.append("<p>Problem with post creation.</p>");
                errContainer.append("<p>" + err.message + "</p>");
            });
        });

        wrapper.on("click", "#create-comment-btn", function () {
            var comment = {
                content: $("#comment-content-input").val(),
                postId: $(this).attr("post-id")
            };

            persister.createComment(comment, function (data) {
                errContainer.append("<p>Comment successfully created.</p>");
            }, function (err) {
                errContainer.append("<p>Problem with comment creation.</p>");
                errContainer.append("<p>" + err.message + "</p>");
            });
        });
    }

    function mediatePosts(selector, errSelector) {
        var errorContainer = $(errSelector);

        persister.getAllPosts(function (data) {
            controls.visualizePostList(data, selector);
        },
        function (err) {
            errContainer.append("<p>Problem with fetching posts.</p>");
            errContainer.append("<p>" + err.message + "</p>");
        });
    }

    function getPostsByTags(tags, selector, errSelector) {
        var errorContainer = $(errSelector);

        persister.getPostsByTags(tags, function (data) {
            controls.visualizePostList(data, selector);
        },
        function (err) {
            errContainer.append("<p>Problem with fetching posts by tags.</p>");
            errContainer.append("<p>" + err.message + "</p>");
        });
    }

    function getPostDetails(id, selector, errSelector) {
        var errorContainer = $(errSelector);

        persister.getPostById(id, function (data) {
            persister.getPostComments(id, function (commentData) {
                controls.visualizePostDetails(data, commentData, selector);
            }, function (err) {
                errContainer.append("<p>Problem with fetching comments of post by id.</p>");
                errContainer.append("<p>" + err.message + "</p>");
            });           
        },
        function (err) {
            errContainer.append("<p>Problem with fetching post by id.</p>");
            errContainer.append("<p>" + err.message + "</p>");
        });
    }


    return {
        isLoggedIn: isLoggedIn,
        getTemplate: getTemplate,
        attachHandlers: attachUIEventHandlers,
        mediatePosts: mediatePosts,
        getPostsByTags: getPostsByTags,
        getPostDetails: getPostDetails
    }
})();