import React, { PureComponent } from 'react';
import { connect } from 'dva';
import moment from "moment";
import { Popconfirm, Table, Row, Col, Card, Form, Input, Select, Icon, Button, Dropdown, Menu, InputNumber, DatePicker, Modal, message, Divider } from 'antd';
import PageHeaderLayout from '../../layouts/PageHeaderLayout';

import styles from '../List/TableList.less';

const FormItem = Form.Item;
const getValue = obj => Object.keys(obj).map(key => obj[key]).join(',');

@connect(state => ({
    user: state.user,
}))
@Form.create()


export default class UserList extends PureComponent {

    state = {
        data: [],
        selectedRows: [],
        formValues: {}
    }
    //初始化时加载表格数据.
    componentDidMount() {
        const { dispatch } = this.props;
        dispatch({
            type: 'user/index',
        })
    }

    //搜索按钮
    search = (e) => {
        const { dispatch, form } = this.props;
        e.preventDefault();
        form.validateFields((err, fieldsValue) => {
            if (err) return;
            const values = {
                ...fieldsValue,
            }
            this.setState({
                formValues: values,
            });
            dispatch({
                type: 'user/search',
                payload: {
                    ...values,
                    pagination: {}
                }
            })
        })
    }
    reset = (e) => {
        console.log(e);
    }
    render() {
        const { data: { list, pagination }, loading } = this.props.user;
        const { getFieldDecorator, getFieldsError, getFieldError, isFieldTouched } = this.props.form;
        const paginationProps = {
            //显示每页显示多少条数据
            showSizeChanger: true,
            //快速跳转到第几页
            showQuickJumper: false,
            ...pagination,
        };
        
        const columns = [
            {
                title: '帐号',
                dataIndex: 'UserName'
            },
            {
                title: '昵称',
                dataIndex: 'NickName'
            },
            {
                title: '用户类型',
                dataIndex: 'UserTypeText'
            },
            {
                title: '注册时间',
                dataIndex: 'CreatedTime',
                render: val => <span>{moment(val).format('YYYY/MM/DD')}</span>
            },
            {
                title: '操作',
                dataIndex: 'action',
                render: (text, record) => (
                    <span>
                        <a >abc</a>
                        <Divider type="vertical" />
                        <Popconfirm title="确定重置密码?" okText="Yes" onConfirm={this.reset} cancelText="No">
                            <a >重置密码</a>
                        </Popconfirm>
                    </span>
                )
            }
        ];
        return (
            //标头
            <PageHeaderLayout title="用户列表">
                {/* 包裹table的白底块 */}
                <Card bordered={false}>
                    <div className={styles.tableList}>
                        <Form onSubmit={this.search} >
                            <Row gutter={{ md: 8, lg: 24, xl: 48 }}>
                                <Col md={6} sm={6}>
                                    <FormItem>
                                        {getFieldDecorator('PhoneNum')(
                                            <Input placeholder="PhoneNum" />
                                        )}
                                    </FormItem>
                                </Col>
                                <Col md={6} sm={6}>
                                    <FormItem>
                                        <Button type="primary" htmlType="submit">查询</Button>
                                    </FormItem>
                                </Col>
                            </Row>
                        </Form>
                        <Table
                            bordered={true}
                            loading={loading}
                            dataSource={list}
                            pagination={paginationProps}
                            columns={columns}
                        />
                    </div>
                </ Card>
            </ PageHeaderLayout>
        )
    }
}
