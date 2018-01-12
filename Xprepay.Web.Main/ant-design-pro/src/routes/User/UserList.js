import React, { PureComponent } from 'react';
import { connect } from 'dva';
import { Table, Row, Col, Card, Form, Input, Select, Icon, Button, Dropdown, Menu, InputNumber, DatePicker, Modal, message } from 'antd';
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
        console.log(styles)
        // const { dispatch } = this.props;
        // dispatch({
        //     type: 'user/search',
        // })
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
    render() {
        console.log(styles)
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
                title: '手机号码',
                dataIndex: 'PhoneNum'
            },
            {
                title: '昵称',
                dataIndex: 'NickName'
            },
            {
                title: '邮箱',
                dataIndex: 'Email'
            },
            {
                title: '生日',
                dataindex: 'Birthday'
            },
            {
                title: '注册时间',
                dataindex: 'CreatedTime'
            },
            {
                title: '操作',
                render: () => (
                    <div>

                    </div>
                )
            }

        ];
        return (
            //标头
            <PageHeaderLayout title="用户列表">
                {/* 包裹table的白底块 */}
                <Card bordered={false}>
                    {/* <div className={styles.tableList}> */}
                    <Form onSubmit={this.search} >
                        <Row gutter={{ md: 8, lg: 24, xl: 48 }}>
                            <Col md={6} sm={6}>
                                <FormItem>
                                    {getFieldDecorator('UserName')(
                                        <Input placeholder="UserName" />
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
                    {/* </div> */}
                </ Card>
            </ PageHeaderLayout>
        )
    }
}
