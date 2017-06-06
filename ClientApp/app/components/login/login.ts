import { Router } from 'aurelia-router';
import * as $ from 'jquery';
import '../../../theme/adminLTE/plugins/iCheck/icheck.js';
import { autoinject } from "aurelia-dependency-injection";
@autoinject()
export class Login {
    constructor(private router: Router) {
    }
    login() {
        this.router.navigateToRoute('admin')
    }
    attached() {
        $(function () {
            $('input').iCheck({
                checkboxClass: 'icheckbox_square-blue',
                radioClass: 'iradio_square-blue',
                increaseArea: '20%' // optional
            });
        });
    }
}