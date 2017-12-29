import React, { PureComponent } from 'react';
import { connect } from 'dva';
import { Table, Row, Col, Card, Form, Input, Select, Icon, Button, Dropdown, Menu, InputNumber, DatePicker, Modal, message } from 'antd';
//import StandardTable from '../../components/StandardTable';
import PageHeaderLayout from '../../layouts/PageHeaderLayout';

import styles from './TableList.less';
const FormItem = Form.Item;
@connect(state => ({
    role: state.role,
}))
@Form.create()
export default class RoleTable extends PureComponent {
    state = {
        data: [],
        pageIndex: 1,
        pageSize: 10,
        selectedRows: [],
        formValues: {}
    }
    componentDidMount() {
        const { dispatch } = this.props;
        dispatch({
            type: 'role/getRoles',
        });
    }
    getRole = () => {
        this.props.dispatch({
            type: 'role/getRoles',
            payload: {
                list: this.state.data
            }
        })
    }
    handleSearch = (e) => {
        e.preventDefault();
        const { dispatch, form } = this.props;
        form.validateFields((err, fieldsValue) => {
            if (err) return;
            const values = {
                ...fieldsValue,
                updatedAt: fieldsValue.updatedAt && fieldsValue.updatedAt.valueOf(),
            };

            // this.setState({
            //     formValues: values,
            // });
            dispatch({
                type: 'role/searchRole',
                payload:{RoleName:values.RoleName}
            });
        })
    }
    render() {
        const columns = [
            {
                title: '编号',
                dataIndex: 'No',
            },
            {
                title: '权限名',
                dataIndex: 'RoleName'
            },
            {
                title: '状态',
                dataIndex: 'Status'
            },
            {
                title: '操作',
                render: () => (
                    <div>
                        <a href="">查看</a>
                        <a href="">删除</a>
                    </div>
                ),
            }
        ];
        const paginationProps = {
            //显示每页显示多少条数据
            showSizeChanger: true,
            //快速跳转到第几页
            showQuickJumper: false,
            pagination: { total: 1, pageSize: 10, current: 1 },
        };

        const { role } = this.props;
        const { getFieldDecorator, getFieldsError, getFieldError, isFieldTouched } = this.props.form;
        return (
            //标头
            <PageHeaderLayout title="用户权限">
                {/* 包裹table的白底块 */}
                <Card bordered={false}>
                    <div className={styles.tableList}>
                        <Form onSubmit={this.handleSearch} >
                            <Row gutter={{ md: 8, lg: 24, xl: 48 }}>
                                <Col md={6} sm={6}>
                                    <FormItem>
                                        {getFieldDecorator('RoleName')(
                                            <Input placeholder="RoleName" />
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
                            loading={role.loading}
                            dataSource={role.list}
                            pagination={paginationProps}
                            columns={columns}
                        />
                    </div>
                </ Card>
            </ PageHeaderLayout>

        )
    }
}