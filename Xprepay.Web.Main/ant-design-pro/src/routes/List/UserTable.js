import React, { PureComponent } from 'react';
import { connect } from 'dva';
import { Table,Row, Col, Card, Form, Input, Select, Icon, Button, Dropdown, Menu, InputNumber, DatePicker, Modal, message } from 'antd';
import StandardTable from '../../components/StandardTable';
import PageHeaderLayout from '../../layouts/PageHeaderLayout';

import styles from './TableList.less';

@connect(state => ({
    rule: state.rule,
  }))

export default class UserTable extends PureComponent{
    state={
        rows:[],
        pageIndex:1,
        pageSize:10
    }
    render (){
        return (
            <Table/>
        )
    }
}