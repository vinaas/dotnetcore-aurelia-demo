import { Aurelia, PLATFORM } from 'aurelia-framework';
import { Router, RouterConfiguration } from 'aurelia-router';
export class App {
    router: Router;

    configureRouter(config: RouterConfiguration, router: Router) {
        config.title = 'Aurelia';
        config.map([{
            route: ['', 'login'],
            name: 'login',
            settings: { icon: 'login' },
            moduleId: PLATFORM.moduleName('../login/login'),
            nav: true,
            title: 'login'
        }, {
            route: 'admin',
            name: 'admin',
            settings: { icon: 'education' },
            moduleId: PLATFORM.moduleName('../admin/admin'),
            nav: true,
            title: 'admin'
        }
        ]);

        this.router = router;
    }
}
