import { routerRedux } from 'dva/router';
import { fakeAccountLogin } from '../services/api';
import { xlogin, ylogin } from '../services/testOne';
import { message } from 'antd';

export default {
  namespace: 'login',

  state: {
    status: undefined,
  },

  effects: {
    *login({ payload }, { call, put }) {
      yield put({
        type: 'changeSubmitting',
        payload: true,
      });
      const response = yield call(xlogin, payload);
      
      yield put({
        type: 'changeLoginStatus',
        payload: response,
      });
      // Login successfully
      if (response.Success) {
        yield put(routerRedux.push('/list/role-list'));
      }else{
        message.error(response.Message)
      }
    },
    *ylogin(_, { call, put }) {
      const response = yield call(ylogin);
      console.log(response);
    },
    *logout(_, { put }) {
      yield put({
        type: 'changeLoginStatus',
        payload: {
          status: false,
        },
      });
      yield put(routerRedux.push('/user/login'));
    },
  },

  reducers: {
    changeLoginStatus(state, { payload }) {
      return {
        ...state,
        status: payload.status,
        type: payload.type,
        submitting: false,
      };
    },
    changeSubmitting(state, { payload }) {
      return {
        ...state,
        submitting: payload,
      };
    },
  },
};
