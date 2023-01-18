import { APP_CONFIG } from '../config.js';
import {
    RoutingController
} from '../swim/routing-controller.js';

export class StrawberryController extends RoutingController {
    async render () {
        var fertilizeDate = this.args.logs.filter((item)=>{
            return item.isFertilize == 1;
        }).reduce((prev, current) => {
            return (prev.createdAt > current.createdAt) ? prev : current
        }, 0);
        
        await super.render({
            ...this.args.strawberry,
            strawberryId: this.args.strawberry.id,
            hasFertilizeDate: fertilizeDate == 0 ? 'd-none' : '',
            fertilizeDay: fertilizeDate == 0 ? '' : moment().diff(moment(fertilizeDate.createdAt),'days'),
            logs: this.args.logs.map(item=>{
                return {
                    ...item,
                    isFertilize: item.isFertilize == 0 ? 'd-none':'',
                    isSick: item.currentState.includes(3)? '':'d-none',
                    isDeath: item.currentState.includes(-1)? '':'d-none',
                    createdAt: item.createdAt.split('T')[0]
                }
            })
        });
    }
}
