import { routerRedux } from 'dva/router';
import { testone } from '../services/testOne';

export default {
    namespace: 'testone',

    state: {
        text: "abc",
    },
    effects: {
        *test1(_, { call, put }) {
          const response = yield call(testone);
          console.log(response);
        },
      },
    reducers: {

      },
}
