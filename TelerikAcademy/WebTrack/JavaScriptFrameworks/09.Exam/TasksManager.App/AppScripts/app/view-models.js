/// <reference path="../libs/_references.js" />


window.vmFactory = (function () {

    function getLogViewModel(successCallbackRegister, successCallbackLogin, successCallbackLogout) {
        var viewModel = {
            username: localStorage.getItem("username") || "username",
            password: "",
            mail: "",
            login: function () {
                debugger;
                var transition = this;
                data.users.login(this.get("username"), this.get("password"))
					.then(function () {
					    if (successCallbackLogin) {
					        successCallbackLogin();
					    }
					}, function (err) {
					    transition.set("message", "Problem with login");
					    setTimeout(function () {
					        transition.set("message", "");
					    }, 5000);
					});
            },
            register: function () {
                var transition = this;
                data.users.register(this.get("username"), this.get("password"), this.get("mail"))
					.then(function () {
					    debugger;
					    transition.set("message", "User registered");
					    setTimeout(function () {
					        transition.set("message", "");
					    }, 5000);
					}, function (err) {
					    transition.set("message", "Problem with register");
					    setTimeout(function () {
					        transition.set("message", "");
					    }, 5000);
					});
            },
            message: "",
            logout: function () {
                debugger;
                var transition = this;
                data.users.logout()
                .then(function () {
                    debugger;
                    if (successCallbackLogout) {
                        debugger;
                        transition.set("username","username");
                        successCallbackLogout();
                    }
                }, function () {
                    debugger;
                    if (successCallbackLogout) {
                        debugger;
                        transition.set("username", "username");
                        successCallbackLogout();
                    }
                });
            }
        };

        debugger;
        return kendo.observable(viewModel);
    }

    function getMainAppointmentsModel() {

        return data.appointments.getAll()
            .then(function (appointments) {
                debugger;
                var viewModel = {
                    message: "",
                    appointments: appointments,
                    subject: "",
                    description: "",
                    date: "",
                    duration: "",
                    createAppointment: function () {
                        debugger;
                        var transition = this;
                        var dateToTransform = this.get("date");
                        debugger;
                        var parsedDate = kendo.toString(dateToTransform, "d-M-yyyy HH:mm:ss");
                        var appData = {
                            subject: this.get("subject"),
                            description: this.get("description"),
                            appointmentDate: parsedDate,
                            duration: this.get("duration")
                        }

                        data.appointments.create(appData)
                            .then(function () {
                                debugger;
                                data.appointments.getAll()
                                    .then(function (appointmentsNew) {
                                        debugger;
                                        transition.set("appointments", appointmentsNew);
                                        $("#app-grid").refresh();
                                    });
                            }, function () {
                                transition.set("message", "Problem with creating the appointment.");
                                setTimeout(function () {
                                    transition.set("message", "");
                                }, 5000);
                            });
                    }
                }

                return kendo.observable(viewModel);
            });
    }

    function getTodayAppointmentsModel() {
        return data.appointments.getToday()
           .then(function (appointments) {
               debugger;
               var viewModel = {
                   appointments: appointments
               }

               return kendo.observable(viewModel);
           });
    }

    function getUpcommingAppointmentsModel() {
        return data.appointments.getUpcomming()
           .then(function (appointments) {
               debugger;
               var viewModel = {
                   appointments: appointments                   
               }

               return kendo.observable(viewModel);
           });
    }

    function getCurrentAppointmentsModel() {
        return data.appointments.getCurrent()
          .then(function (appointments) {
              debugger;
              var viewModel = {
                  appointments: appointments
              }

              return kendo.observable(viewModel);
          });
    }

    function getDateAppointmentsModel() {
        var viewModel = {
            appointments: [],
            date: "",
            message: "",
            getAppointments: function () {
                debugger;
                var transition = this;
                var dateToTransform = this.get("date");
                debugger;
                //var parsedDate = dateToTransform;
                var parsedDate = kendo.toString(dateToTransform, "d-M-yyyy");

                data.appointments.getByDate(parsedDate)
                            .then(function (appointmentsNew) {
                                debugger;
                                transition.set("appointments", appointmentsNew);
                                $("#app-grid").refresh();
                            }, function () {
                                transition.set("message", "Problem with search");
                                setTimeout(function () {
                                    transition.set("message", "");
                                }, 5000);
                            });
                    }
            }

        return kendo.observable(viewModel);
    }

    function getTodoMainModel(routingFunction) {
        return data.lists.getAll()
            .then(function (lists) {
                var viewModel = {
                    lists: lists,
                    title: "",
                    message: "",
                    seeDetails: function (ev) {
                        debugger;
                        var id = $(ev.target).attr("todo-id");
                        routingFunction(id);
                    },
                    createList: function () {
                        var transition = this;
                        var listTitle = this.get("title");
                        data.lists.createList(listTitle)
                            .then(function () {
                                data.lists.getAll()
                                    .then(function (listDataUpdated) {
                                        transition.set("lists", listDataUpdated);
                                    }
                                    );
                            }, function () {
                                transition.set("message", "Problem with creating ToDoList");
                                setTimeout(function () {
                                    transition.set("message", "");
                                }, 5000);
                            });
                    }
                }

                return kendo.observable(viewModel);
            });
    }

    function getIndividualListModel(listId) {
        return data.lists.getIndividual(listId)
            .then(function (listData) {
                var vm = {
                    id: listData.id,
                    message: "",
                    todoText: "",
                    title: listData.title,
                    todos: listData.todos,
                    changeState: function (ev) {
                        var transition = this;
                        var id = $(ev.target).attr("todo-id");
                        data.todos.changeState(id)
                            .then(function () {
                                data.lists.getIndividual(listId)
                                    .then(function (newData) {
                                        transition.set("todos", newData.todos);
                                    });
                            }, function () {
                                data.lists.getIndividual(listId)
                                    .then(function (newData) {
                                        transition.set("todos", newData.todos);
                                    });
                            });
                    },
                    createTodo: function (ev) {
                        debugger;
                        var transition = this;
                        var id = $(ev.target).attr("list-id");
                        data.lists.addTodo(id, this.get("todoText"))
                            .then(function () {
                                debugger;
                                data.lists.getIndividual(listId)
                                    .then(function (newListData) {
                                        debugger;
                                        transition.set("todos", newListData.todos);
                                    });
                            }, function () {
                                transition.set("message", "Problem with creating ToDo task");
                                setTimeout(function () {
                                    transition.set("message", "");
                                }, 5000);
                            });
                    }
                };

                return kendo.observable(vm);
            });
    }

    

    return {
        getLogViewModel: getLogViewModel,
        getUpcommingAppointmentsModel: getUpcommingAppointmentsModel,
        getMainAppointmentsModel: getMainAppointmentsModel,
        getTodayAppointmentsModel: getTodayAppointmentsModel,
        getCurrentAppointmentsModel: getCurrentAppointmentsModel,
        getDateAppointmentsModel: getDateAppointmentsModel,
        getTodoMainModel: getTodoMainModel,
        getIndividualListModel: getIndividualListModel,
        setPersister: function (persister) {
            data = persister
        }
    };
}());