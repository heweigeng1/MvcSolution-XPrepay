import { routerRedux } from 'dva/router';
import { testone } from '../services/testOne';

export default {
  namespace: 'testone',

  state: {
    text: "abc",
  },
  effects: {
    *test1({ payload }, { call, put }) {
      const response = yield call(testone);
      yield put({
        type: 'saveTestOne',
        payload: {
          count: 10,
          name: "tom"
        }
      })
    },
  },
  reducers: {
    saveTestOne(state, { payload }) {
      console.log(payload)
      return {
        ...state,
        myage:payload.count,
      }
    }
  },
}
