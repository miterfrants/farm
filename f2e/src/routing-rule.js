import { APP_CONFIG } from './config.js';
import { FormController } from './controllers/form.controller.js';
// TODO :「隱私權政策」內容寫完後，可以打開，並加上 RoutingRule 相關設定
// import { AboutController } from './controllers/about.controller.js';
import { MainController } from './controllers/main.controller.js';
import { MasterController } from './controllers/master.controller.js';
import { RootController } from './controllers/root.controller.js';
import { StrawberryListController } from './controllers/strawberry-list.controller.js';
import { StrawberryController } from './controllers/strawberry.controller.js';
import { StrawberryDataService } from './dataservices/strawberry.dataservice.js';
import { Toaster } from './util/toaster.js';
import { LogDataService } from './dataservices/log.dataservice.js';

const gTag = {
    dependency: {
        url: `https://www.googletagmanager.com/gtag/js?id=${APP_CONFIG.GA_PROPERTY_ID}`,
        checkVariable: 'dataLayer',
        defer: true,
        async: true
    },
    prepareData: {
        key: 'gtag',
        func: () => {
            window.dataLayer = window.dataLayer || [];
            if (!window.gtag) {
                function gtag () {
                    window.dataLayer.push(arguments);
                }
                gtag('js', new Date());
                gtag('config', APP_CONFIG.GA_PROPERTY_ID);
                window.gtag = gtag;
            }

            return window.gtag;
        }
    }
};

export const RoutingRule = [{
    path: '',
    controller: RootController,
    dependency: [{
        url: '/third-party/jwt-decode.min.js',
        checkVariable: 'jwt_decode'
    }, gTag.dependency, {
        url: '/third-party/moment.js',
        checkVariable: 'moment'
    }],
    children: [{
        path: '',
        controller: MasterController,
        html: '/template/master.html',
        children: [{
            path: '/',
            controller: MainController,
            html: '/template/main.html',
            prepareData: [gTag.prepareData],
            children: [{
                path: 'strawberries/',
                controller: StrawberryListController,
                html: '/template/strawberry-list.html',
                prepareData: [{
                    key: 'strawberries',
                    func: async () => {
                        const result = await StrawberryDataService.GetList();
                        return result.data;
                    }
                }],
                children: [{
                    path: '{id}/',
                    controller: StrawberryController,
                    html: '/template/strawberry.html',
                    prepareData: [{
                        key: 'strawberry',
                        func: async (args) => {
                            let target = args.strawberries.find(item=>item.id === args._id);
                            if (!target) {
                                return (await StrawberryDataService.GetOne(args._id)).data;
                            }
                        }
                    }, {
                        key: 'logs',
                        func: async (args) => {
                            return (await LogDataService.GetList(args._id)).data;
                        }
                    }],
                    children: [{
                        path: 'logs/create/',
                        controller: FormController,
                        html: '/template/strawberry-form.html',
                        prepareData: [{
                            key: 'log',
                            func: async (args) => {
                                const log = (await LogDataService.GetList(args._id, 1, 1)).data[0];
                                return log || {
                                    oldLeaves: 0,
                                    tenderLeaves: 0,
                                    leavesBud:0,
                                    flowerBud: 0,
                                    flower:0,
                                    fruit: 0,
                                    currentState: '[0]',
                                    stolon: 0,
                                    isRepotting: 0,
                                    isFertilize: 0,
                                    isPruning: 0,
                                    comment:''
                                }
                            }
                        }],
                    },{
                        path: 'logs/{logId}/',
                        controller: FormController,
                        html: '/template/strawberry-form.html',
                        prepareData: [{
                            key: 'log',
                            func: async (args) => {
                                return (await LogDataService.GetOne(args._id, args._logId)).data
                            }
                        }],
                    }]
                }]
            }]
        }]
    }]
}];
