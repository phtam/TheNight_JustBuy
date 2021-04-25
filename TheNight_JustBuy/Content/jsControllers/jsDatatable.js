//Coupon
$("#tbl_Coupons").DataTable({
    "responsive": true,
    "autoWidth": false,
    "dom": '<"pull-left"B><"pull-right"f>rt<"row"<"col-sm-4"l><"col-sm-4"i><"col-sm-4"p>>',
    "buttons": [
        {
            extend: 'excel',
            text: '<i class="fas fa-file-excel"></i> Excel',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-success btn-sm'
        },
        {
            extend: 'pdf',
            text: '<i class="fas fa-file-pdf"></i> PDF',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-danger btn-sm'
        },
        {
            extend: 'print',
            text: '<i class="fas fa-print"></i> Print',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-info btn-sm'
        }
    ],
    "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
    "aoColumns": [
        null,
        null,
        null,
        null,
        null,
        null,
        { "width": "20%", "targets": 0 }
    ]
});
//AboutUs
$("#tbl_AboutUS").DataTable({
    "responsive": true,
    "autoWidth": false,
    "dom": '<"pull-left"B><"pull-right"f>rt<"row"<"col-sm-4"l><"col-sm-4"i><"col-sm-4"p>>',
    "buttons": [
        {
            extend: 'excel',
            text: '<i class="fas fa-file-excel"></i> Excel',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-success btn-sm'
        },
        {
            extend: 'pdf',
            text: '<i class="fas fa-file-pdf"></i> PDF',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-danger btn-sm'
        },
        {
            extend: 'print',
            text: '<i class="fas fa-print"></i> Print',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-info btn-sm'
        }
    ],
    "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
    "aoColumns": [
        null,
        null,
        { "width": "20%", "targets": 0 },
    ]
});
//Admin
$("#tbl_Admin").DataTable({
    "destroy": true,
    "responsive": true,
    "autoWidth": false,
    "dom": '<"pull-left"B><"pull-right"f>rt<"row"<"col-sm-4"l><"col-sm-4"i><"col-sm-4"p>>',
    "buttons": [
        {
            extend: 'excel',
            text: '<i class="fas fa-file-excel"></i> Excel',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-success btn-sm'
        },
        {
            extend: 'pdf',
            text: '<i class="fas fa-file-pdf"></i> PDF',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-danger btn-sm'
        },
        {
            extend: 'print',
            text: '<i class="fas fa-print"></i> Print',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-info btn-sm'
        }
    ],
    "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
    "aoColumns": [
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        { Width: '80px' }
    ],
    
});


//Instructor
$("#tbl_Instructors").DataTable({
    "destroy": true,
    "responsive": true,
    "autoWidth": false,
    "dom": '<"pull-left"B><"pull-right"f>rt<"row"<"col-sm-4"l><"col-sm-4"i><"col-sm-4"p>>',
    "buttons": [
        {
            extend: 'excel',
            text: '<i class="fas fa-file-excel"></i> Excel',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-success btn-sm'
        },
        {
            extend: 'pdf',
            text: '<i class="fas fa-file-pdf"></i> PDF',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-danger btn-sm'
        },
        {
            extend: 'print',
            text: '<i class="fas fa-print"></i> Print',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-info btn-sm'
        }
    ],
    "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
    "aoColumns": [
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        { Width: '80px' }
    ]
});
//Student
$("#tbl_Students").DataTable({
    "destroy": true,
    "responsive": true,
    "autoWidth": false,
    "dom": '<"pull-left"B><"pull-right"f>rt<"row"<"col-sm-4"l><"col-sm-4"i><"col-sm-4"p>>',
    "buttons": [
        {
            extend: 'excel',
            text: '<i class="fas fa-file-excel"></i> Excel',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-success btn-sm'
        },
        {
            extend: 'pdf',
            text: '<i class="fas fa-file-pdf"></i> PDF',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-danger btn-sm'
        },
        {
            extend: 'print',
            text: '<i class="fas fa-print"></i> Print',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-info btn-sm'
        }
    ],
    "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
    "aoColumns": [
        { "width": "10%", "targets": 0 },
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        { "width": "10%", "targets": 0 },
        { "width": "10%", "targets": 0 }
    ]
});

$("#tbl_BlogCategories").DataTable({
    "responsive": true,
    "autoWidth": false,
    "dom": '<"pull-left"B><"pull-right"f>rt<"row"<"col-sm-4"l><"col-sm-4"i><"col-sm-4"p>>',
    "buttons": [
        {
            extend: 'excel',
            text: '<i class="fas fa-file-excel"></i> Excel',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-success btn-sm'
        },
        {
            extend: 'pdf',
            text: '<i class="fas fa-file-pdf"></i> PDF',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-danger btn-sm'
        },
        {
            extend: 'print',
            text: '<i class="fas fa-print"></i> Print',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-info btn-sm'
        }
    ],
    "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
    "aoColumns": [
        null,
        null,
        { Width: '180px' }
    ]
});

$("#tbl_BlogComments").DataTable({
    "responsive": true,
    "autoWidth": false,
    "dom": '<"pull-left"B><"pull-right"f>rt<"row"<"col-sm-4"l><"col-sm-4"i><"col-sm-4"p>>',
    "buttons": [
        {
            extend: 'excel',
            text: '<i class="fas fa-file-excel"></i> Excel',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-success btn-sm'
        },
        {
            extend: 'pdf',
            text: '<i class="fas fa-file-pdf"></i> PDF',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-danger btn-sm'
        },
        {
            extend: 'print',
            text: '<i class="fas fa-print"></i> Print',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-info btn-sm'
        }
    ],
    "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
    "order": [[3, "desc"]],
    "aoColumns": [
        null,
        null,
        { "width": "30%", "targets": 0 },
        null,
        null,
        null,
        { "width": "15%", "targets": 0 },
    ]
});

$("#tbl_Contacts").DataTable({
    "responsive": true,
    "autoWidth": false,
    "dom": '<"pull-left"B><"pull-right"f>rt<"row"<"col-sm-4"l><"col-sm-4"i><"col-sm-4"p>>',
    "buttons": [
        {
            extend: 'excel',
            text: '<i class="fas fa-file-excel"></i> Excel',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-success btn-sm'
        },
        {
            extend: 'pdf',
            text: '<i class="fas fa-file-pdf"></i> PDF',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-danger btn-sm'
        },
        {
            extend: 'print',
            text: '<i class="fas fa-print"></i> Print',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-info btn-sm'
        }
    ],
    "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
    "aoColumns": [
        null,
        null,
        null,
        null,
        null,
        { Width: '180px' }
    ]
});

$("#tbl_CourseComments").DataTable({
    "responsive": true,
    "autoWidth": false,
    "dom": '<"pull-left"B><"pull-right"f>rt<"row"<"col-sm-4"l><"col-sm-4"i><"col-sm-4"p>>',
    "buttons": [
        {
            extend: 'excel',
            text: '<i class="fas fa-file-excel"></i> Excel',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-success btn-sm'
        },
        {
            extend: 'pdf',
            text: '<i class="fas fa-file-pdf"></i> PDF',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-danger btn-sm'
        },
        {
            extend: 'print',
            text: '<i class="fas fa-print"></i> Print',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-info btn-sm'
        }
    ],
    "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
    "order": [[4, "desc"]],
    "aoColumns": [
        null,
        null,
        null,
        null,
        null,
        null,
        { "width": "20%", "targets": 0 }
    ]
});



$("#tbl_Grades").DataTable({
    "responsive": true,
    "autoWidth": false,
    "dom": '<"pull-left"B><"pull-right"f>rt<"row"<"col-sm-4"l><"col-sm-4"i><"col-sm-4"p>>',
    "buttons": [
        {
            extend: 'excel',
            text: '<i class="fas fa-file-excel"></i> Excel',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-success btn-sm'
        },
        {
            extend: 'pdf',
            text: '<i class="fas fa-file-pdf"></i> PDF',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-danger btn-sm'
        },
        {
            extend: 'print',
            text: '<i class="fas fa-print"></i> Print',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-info btn-sm'
        }
    ],
    "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
    "aoColumns": [
        null,
        null,
        null,
        null,
        { Width: '180px' }
    ]
});


$("#tbl_LectureComments").DataTable({
    "responsive": true,
    "autoWidth": false,
    "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
    "order": [[4, "desc"]],
    "aoColumns": [
        null,
        null,
        null,
        null,
        null,
        null,
        { "width": "20%", "targets": 0 }
    ]
});


$("#tbl_Payments").DataTable({
    "responsive": true,
    "autoWidth": false,
    "dom": '<"pull-left"B><"pull-right"f>rt<"row"<"col-sm-4"l><"col-sm-4"i><"col-sm-4"p>>',
    "buttons": [
        {
            extend: 'excel',
            text: '<i class="fas fa-file-excel"></i> Excel',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-success btn-sm'
        },
        {
            extend: 'pdf',
            text: '<i class="fas fa-file-pdf"></i> PDF',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-danger btn-sm'
        },
        {
            extend: 'print',
            text: '<i class="fas fa-print"></i> Print',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-info btn-sm'
        }
    ],
    "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
    "aoColumns": [
        null,
        null,
        { Width: '180px' }
    ]
});

$("#tbl_QuestionType").DataTable({
    "responsive": true,
    "autoWidth": false,
    "dom": '<"pull-left"B><"pull-right"f>rt<"row"<"col-sm-4"l><"col-sm-4"i><"col-sm-4"p>>',
    "buttons": [
        {
            extend: 'excel',
            text: '<i class="fas fa-file-excel"></i> Excel',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-success btn-sm'
        },
        {
            extend: 'pdf',
            text: '<i class="fas fa-file-pdf"></i> PDF',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-danger btn-sm'
        },
        {
            extend: 'print',
            text: '<i class="fas fa-print"></i> Print',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-info btn-sm'
        }
    ],
    "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
    "aoColumns": [
        null,
        null,
        { Width: '180px' }
    ]
});
//Registration
$("#tbl_Registration").DataTable({
    "responsive": true,
    "autoWidth": false,
    "dom": '<"pull-left"B><"pull-right"f>rt<"row"<"col-sm-4"l><"col-sm-4"i><"col-sm-4"p>>',
    "buttons": [
        {
            extend: 'excel',
            text: '<i class="fas fa-file-excel"></i> Excel',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-success btn-sm'
        },
        {
            extend: 'pdf',
            text: '<i class="fas fa-file-pdf"></i> PDF',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-danger btn-sm'
        },
        {
            extend: 'print',
            text: '<i class="fas fa-print"></i> Print',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-info btn-sm'
        }
    ],
    "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
    "aoColumns": [
        null,
        null,
        { "width": "20%", "targets": 0 },
        null,
        null,
        null,
        null,
        null,
        { "width": "30%", "targets": 0 },
    ]
});

$("#tbl_ReplyingBlogComments").DataTable({
    "responsive": true,
    "autoWidth": false,
    "dom": '<"pull-left"B><"pull-right"f>rt<"row"<"col-sm-4"l><"col-sm-4"i><"col-sm-4"p>>',
    "buttons": [
        {
            extend: 'excel',
            text: '<i class="fas fa-file-excel"></i> Excel',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-success btn-sm'
        },
        {
            extend: 'pdf',
            text: '<i class="fas fa-file-pdf"></i> PDF',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-danger btn-sm'
        },
        {
            extend: 'print',
            text: '<i class="fas fa-print"></i> Print',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-info btn-sm'
        }
    ],
    "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
    "aoColumns": [
        null,
        null,
        null,
        null,
        { Width: '180px' }
    ]
});

$("#tbl_RepyingCourseComments").DataTable({
    "responsive": true,
    "autoWidth": false,
    "dom": '<"pull-left"B><"pull-right"f>rt<"row"<"col-sm-4"l><"col-sm-4"i><"col-sm-4"p>>',
    "buttons": [
        {
            extend: 'excel',
            text: '<i class="fas fa-file-excel"></i> Excel',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-success btn-sm'
        },
        {
            extend: 'pdf',
            text: '<i class="fas fa-file-pdf"></i> PDF',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-danger btn-sm'
        },
        {
            extend: 'print',
            text: '<i class="fas fa-print"></i> Print',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-info btn-sm'
        }
    ],
    "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
    "order": [[2, "desc"]],
    "aoColumns": [
        null,
        null,
        null,
        { Width: '180px' }
    ]
});

$("#tbl_ReplyingLectureComments").DataTable({
    "responsive": true,
    "autoWidth": false,
    "dom": '<"pull-left"B><"pull-right"f>rt<"row"<"col-sm-4"l><"col-sm-4"i><"col-sm-4"p>>',
    "buttons": [
        {
            extend: 'excel',
            text: '<i class="fas fa-file-excel"></i> Excel',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-success btn-sm'
        },
        {
            extend: 'pdf',
            text: '<i class="fas fa-file-pdf"></i> PDF',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-danger btn-sm'
        },
        {
            extend: 'print',
            text: '<i class="fas fa-print"></i> Print',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-info btn-sm'
        }
    ],
    "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
    "aoColumns": [
        null,
        null,
        null,
        null,
        { Width: '180px' }
    ]
});

$("#tbl_UserStatus").DataTable({
    "responsive": true,
    "autoWidth": false,
    "dom": '<"pull-left"B><"pull-right"f>rt<"row"<"col-sm-4"l><"col-sm-4"i><"col-sm-4"p>>',
    "buttons": [
        {
            extend: 'excel',
            text: '<i class="fas fa-file-excel"></i> Excel',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-success btn-sm'
        },
        {
            extend: 'pdf',
            text: '<i class="fas fa-file-pdf"></i> PDF',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-danger btn-sm'
        },
        {
            extend: 'print',
            text: '<i class="fas fa-print"></i> Print',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-info btn-sm'
        }
    ],
    "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
    "aoColumns": [
        null,
        null,
        { Width: '180px' }
    ]
});

$("#tbl_Blogs").DataTable({
    "responsive": true,
    "autoWidth": false,
    "dom": '<"pull-left"B><"pull-right"f>rt<"row"<"col-sm-4"l><"col-sm-4"i><"col-sm-4"p>>',
    "buttons": [
        {
            extend: 'excel',
            text: '<i class="fas fa-file-excel"></i> Excel',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-success btn-sm'
        },
        {
            extend: 'pdf',
            text: '<i class="fas fa-file-pdf"></i> PDF',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-danger btn-sm'
        },
        {
            extend: 'print',
            text: '<i class="fas fa-print"></i> Print',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-info btn-sm'
        }
    ],
    "order": [[2, "desc"]],
    "aoColumns": [
        { "width": "25%", "targets": 0 },
        null,
        null,
        null,
        null,
        null,
        { "width": "25%", "targets": 0 },
    ]
});

$("#tbl_Categories").DataTable({
    "responsive": true,
    "autoWidth": false,
    "dom": '<"pull-left"B><"pull-right"f>rt<"row"<"col-sm-4"l><"col-sm-4"i><"col-sm-4"p>>',
    "buttons": [
        {
            extend: 'excel',
            text: '<i class="fas fa-file-excel"></i> Excel',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-success btn-sm'
        },
        {
            extend: 'pdf',
            text: '<i class="fas fa-file-pdf"></i> PDF',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-danger btn-sm'
        },
        {
            extend: 'print',
            text: '<i class="fas fa-print"></i> Print',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-info btn-sm'
        }
    ],
    "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
    "aoColumns": [
        null,
        null,
        null,
        null,
        { width: '80px' }
    ]
});

$(function () {
    $("#tbl_Course").DataTable({
        "destroy": true,
        "responsive": true,
        "autoWidth": false,
        "dom": '<"pull-left"B><"pull-right"f>rt<"row"<"col-sm-4"l><"col-sm-4"i><"col-sm-4"p>>',
        "buttons": [
            {
                extend: 'excel',
                text: '<i class="fas fa-file-excel"></i> Excel',
                exportOptions: {
                    modifier: {
                        page: 'current'
                    }
                },
                className: 'btn btn-success btn-sm'
            },
            {
                extend: 'pdf',
                text: '<i class="fas fa-file-pdf"></i> PDF',
                exportOptions: {
                    modifier: {
                        page: 'current'
                    }
                },
                className: 'btn btn-danger btn-sm'
            },
            {
                extend: 'print',
                text: '<i class="fas fa-print"></i> Print',
                exportOptions: {
                    modifier: {
                        page: 'current'
                    }
                },
                className: 'btn btn-info btn-sm'
            }
        ],
        "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
        "aoColumns": [
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            { "width": "10%", "targets": 0 },
            { "width": "10%", "targets": 0 }
        ]
    });
});
  
$("#tbl_Certificate").DataTable({
    "destroy": true,
    "responsive": true,
    "autoWidth": false,
    "order": [[5, "desc"]],
    "dom": '<"pull-left"B><"pull-right"f>rt<"row"<"col-sm-4"l><"col-sm-4"i><"col-sm-4"p>>',
    "buttons": [
        {
            extend: 'excel',
            text: '<i class="fas fa-file-excel"></i> Excel',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-success btn-sm'
        },
        {
            extend: 'pdf',
            text: '<i class="fas fa-file-pdf"></i> PDF',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-danger btn-sm'
        },
        {
            extend: 'print',
            text: '<i class="fas fa-print"></i> Print',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-info btn-sm'
        }
    ],
    "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
    "aoColumns": [
        null,
        null,
        null,
        null,
        null,
        null,
        { Width: '180px' }
    ]
});


$("#tbl_Lecture").DataTable({
    "destroy": true,
    "responsive": true,
    "autoWidth": false,
    "dom": '<"pull-left"B><"pull-right"f>rt<"row"<"col-sm-4"l><"col-sm-4"i><"col-sm-4"p>>',
    "buttons": [
        {
            extend: 'excel',
            text: '<i class="fas fa-file-excel"></i> Excel',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-success btn-sm'
        },
        {
            extend: 'pdf',
            text: '<i class="fas fa-file-pdf"></i> PDF',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-danger btn-sm'
        },
        {
            extend: 'print',
            text: '<i class="fas fa-print"></i> Print',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-info btn-sm'
        }
    ],
    "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
    "aoColumns": [
        null,
        null,
        { "width": "10%", "targets": 0 }
    ]
});



$("#tbl_Question").DataTable({
    "destroy": true,
    "responsive": true,
    "autoWidth": false,
    "dom": '<"pull-left"B><"pull-right"f>rt<"row"<"col-sm-4"l><"col-sm-4"i><"col-sm-4"p>>',
    "buttons": [
        {
            extend: 'excel',
            text: '<i class="fas fa-file-excel"></i> Excel',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-success btn-sm'
        },
        {
            extend: 'pdf',
            text: '<i class="fas fa-file-pdf"></i> PDF',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-danger btn-sm'
        },
        {
            extend: 'print',
            text: '<i class="fas fa-print"></i> Print',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-info btn-sm'
        }
    ],
    "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
    "aoColumns": [
        null,
        null,
        null,
        null,
        null,
        null
    ]
});

$("#tbl_Question_m").DataTable({
    "destroy": true,
    "responsive": true,
    "autoWidth": false,
    "dom": '<"pull-left"B><"pull-right"f>rt<"row"<"col-sm-4"l><"col-sm-4"i><"col-sm-4"p>>',
    "buttons": [
        {
            extend: 'excel',
            text: '<i class="fas fa-file-excel"></i> Excel',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-success btn-sm'
        },
        {
            extend: 'pdf',
            text: '<i class="fas fa-file-pdf"></i> PDF',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-danger btn-sm'
        },
        {
            extend: 'print',
            text: '<i class="fas fa-print"></i> Print',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-info btn-sm'
        }
    ],
    "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
    "aoColumns": [
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        null
    ]
});

$("#tbl_Examination").DataTable({
    "destroy": true,
    "responsive": true,
    "autoWidth": false,
    "order": [[4, "desc"]],
    "dom": '<"pull-left"B><"pull-right"f>rt<"row"<"col-sm-4"l><"col-sm-4"i><"col-sm-4"p>>',
    "buttons": [
        {
            extend: 'excel',
            text: '<i class="fas fa-file-excel"></i> Excel',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-success btn-sm'
        },
        {
            extend: 'pdf',
            text: '<i class="fas fa-file-pdf"></i> PDF',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-danger btn-sm'
        },
        {
            extend: 'print',
            text: '<i class="fas fa-print"></i> Print',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-info btn-sm'
        }
    ],
    "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
    "aoColumns": [
        { "width": "25%", "targets": 0 },
        null,
        null,
        null,
        null,
        null,
        { "width": "10%", "targets": 0 },
        { "width": "10%", "targets": 0 }
    ]
});

$("#tbl_ExamResult").DataTable({
    "destroy": true,
    "responsive": true,
    "autoWidth": false,
    "dom": '<"pull-left"B><"pull-right"f>rt<"row"<"col-sm-4"l><"col-sm-4"i><"col-sm-4"p>>',
    "buttons": [
        {
            extend: 'excel',
            text: '<i class="fas fa-file-excel"></i> Excel',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-success btn-sm'
        },
        {
            extend: 'pdf',
            text: '<i class="fas fa-file-pdf"></i> PDF',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-danger btn-sm'
        },
        {
            extend: 'print',
            text: '<i class="fas fa-print"></i> Print',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-info btn-sm'
        }
    ],
    "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
    "aoColumns": [
        null,
        null,
        null,
        null,
        null
    ]
});

$("#tbl_ReplyBlogComments").DataTable({
    "responsive": true,
    "autoWidth": false,
    "order": [[2, "desc"]],
    "dom": '<"pull-left"B><"pull-right"f>rt<"row"<"col-sm-4"l><"col-sm-4"i><"col-sm-4"p>>',
    "buttons": [
        {
            extend: 'excel',
            text: '<i class="fas fa-file-excel"></i> Excel',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-success btn-sm'
        },
        {
            extend: 'pdf',
            text: '<i class="fas fa-file-pdf"></i> PDF',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-danger btn-sm'
        },
        {
            extend: 'print',
            text: '<i class="fas fa-print"></i> Print',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-info btn-sm'
        }
    ],
    "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
    "aoColumns": [
        { "width": "15%", "targets": 0 },
        null,
        { "width": "10%", "targets": 0 },
        { "width": "18%", "targets": 0 }
    ]
});

$("#tbl_ExamResultDetail").DataTable({
    "destroy": true,
    "responsive": true,
    "autoWidth": false,
    "order": [[4, "desc"]],
    "dom": '<"pull-left"B><"pull-right"f>rt<"row"<"col-sm-4"l><"col-sm-4"i><"col-sm-4"p>>',
    "buttons": [
        {
            extend: 'excel',
            text: '<i class="fas fa-file-excel"></i> Excel',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-success btn-sm'
        },
        {
            extend: 'pdf',
            text: '<i class="fas fa-file-pdf"></i> PDF',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-danger btn-sm'
        },
        {
            extend: 'print',
            text: '<i class="fas fa-print"></i> Print',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-info btn-sm'
        }
    ],
    "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
    "aoColumns": [
        { "width": "25%", "targets": 0 },
        null,
        null,
        null,
        null,
        null
    ]
});

$("#tbl_LectureComments").DataTable({
    "destroy": true,
    "responsive": true,
    "autoWidth": false,
    "dom": '<"pull-left"B><"pull-right"f>rt<"row"<"col-sm-4"l><"col-sm-4"i><"col-sm-4"p>>',
    "buttons": [
        {
            extend: 'excel',
            text: '<i class="fas fa-file-excel"></i> Excel',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-success btn-sm'
        },
        {
            extend: 'pdf',
            text: '<i class="fas fa-file-pdf"></i> PDF',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-danger btn-sm'
        },
        {
            extend: 'print',
            text: '<i class="fas fa-print"></i> Print',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-info btn-sm'
        }
    ],
    "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
    "order": [[4, "desc"]],
    "aoColumns": [
        null,
        null,
        null,
        null,
        null,
        null,
        { "width": "20%", "targets": 0 }
    ]
});

$("#tbl_BlogApproval").DataTable({
    "responsive": true,
    "autoWidth": false,
    "dom": '<"pull-left"B><"pull-right"f>rt<"row"<"col-sm-4"l><"col-sm-4"i><"col-sm-4"p>>',
    "buttons": [
        {
            extend: 'excel',
            text: '<i class="fas fa-file-excel"></i> Excel',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-success btn-sm'
        },
        {
            extend: 'pdf',
            text: '<i class="fas fa-file-pdf"></i> PDF',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-danger btn-sm'
        },
        {
            extend: 'print',
            text: '<i class="fas fa-print"></i> Print',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-info btn-sm'
        }
    ],
    "order": [[2, "desc"]],
    "aoColumns": [
        { "width": "25%", "targets": 0 },
        null,
        null,
        null,
        null,
        { "width": "12%", "targets": 0 }
    ]
});

$("#tbl_Orders").DataTable({
    "responsive": true,
    "autoWidth": false,
    "dom": '<"pull-left"B><"pull-right"f>rt<"row"<"col-sm-4"l><"col-sm-4"i><"col-sm-4"p>>',
    "buttons": [
        {
            extend: 'excel',
            text: '<i class="fas fa-file-excel"></i> Excel',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-success btn-sm'
        },
        {
            extend: 'pdf',
            text: '<i class="fas fa-file-pdf"></i> PDF',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-danger btn-sm'
        },
        {
            extend: 'print',
            text: '<i class="fas fa-print"></i> Print',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-info btn-sm'
        }
    ],
    "order": [[2, "desc"]],
    "aoColumns": [
        null,
        null,
        null,
        null,
        null,
        null,
        null,
        { "width": "15%", "targets": 0 }
    ]
});

$("#tbl_OrderDetail").DataTable({
    "responsive": true,
    "autoWidth": false,
    "dom": '<"pull-left"B><"pull-right"f>rt<"row"<"col-sm-4"l><"col-sm-4"i><"col-sm-4"p>>',
    "buttons": [
        {
            extend: 'excel',
            text: '<i class="fas fa-file-excel"></i> Excel',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-success btn-sm'
        },
        {
            extend: 'pdf',
            text: '<i class="fas fa-file-pdf"></i> PDF',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-danger btn-sm'
        },
        {
            extend: 'print',
            text: '<i class="fas fa-print"></i> Print',
            exportOptions: {
                modifier: {
                    page: 'current'
                }
            },
            className: 'btn btn-info btn-sm'
        }
    ],
    "aoColumns": [
        null,
        null
    ]
});