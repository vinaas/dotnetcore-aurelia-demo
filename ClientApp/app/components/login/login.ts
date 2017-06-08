import axios from 'axios';
import { Router } from 'aurelia-router';
import * as $ from 'jquery';
import '../../../theme/adminLTE/plugins/iCheck/icheck.js';
import { autoinject } from "aurelia-dependency-injection";
import { getLogger } from "aurelia-logging";
const logger = getLogger("Login")
@autoinject()
export class Login {
    private model: any = {};
    constructor(private router: Router) {
    }
    async login() {
        logger.info("model", this.model);
        this.model.RememberMe = false;
        let result = await axios.post('/api/account/login', this.model)
        logger.info("result", result)
        // if (result.data) {
        //     this.router.navigateToRoute('admin')
        // }

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