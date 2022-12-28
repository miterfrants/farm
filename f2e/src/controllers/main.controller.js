import { APP_CONFIG } from '../config.js';
import {
    RoutingController
} from '../swim/routing-controller.js';

export class MainController extends RoutingController {
    async render () {
        await super.render({
            ...this.args.me,
            numOfRegisteredUser: this.args.numOfRegisteredUser,
            user: this.args.me,
            isSignInInvisible: this.args.me && this.args.me.id ? 'd-none' : ''
        });
    }

    computed () {
        return [{
            watchKey: 'numOfRegisteredUser',
            variableName: 'numberOfPromotedUser',
            value: () => {
                return this.pageVariable.numOfRegisteredUser && this.pageVariable.numOfRegisteredUser > 300 ? 0 : 300 - this.pageVariable.numOfRegisteredUser;
            }
        }];
    }
}
