import { Aurelia, PLATFORM } from 'aurelia-framework';
import { Router, RouterConfiguration } from 'aurelia-router';

export class Admin {
    router: Router;

    configureRouter(config: RouterConfiguration, router: Router) {
        config.title = 'Admin';
        config.map([{
            route: ['', 'dashboard'],
            name: 'dashboard',
            settings: { icon: 'login' },
            moduleId: PLATFORM.moduleName('../../components/dashboard/dashboard'),
            nav: true,
            title: 'dashboard'
        }
        ]);

        this.router = router;
    }
    attached() {
        var script = document.createElement("script");
        script.src = "/dist/theme/adminLTE/js/app.min.js";
        script.type = "text/javascript";

        document.getElementsByTagName("head")[0].appendChild(script);

    }
}
