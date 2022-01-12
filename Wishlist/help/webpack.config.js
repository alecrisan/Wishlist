const HtmlWebpackPlugin = require('html-webpack-plugin');
const webpack = require('webpack');
const ModuleFederationPlugin = require('webpack/lib/container/ModuleFederationPlugin');
const deps = require('./package.json').dependencies;
const path = require('path');
module.exports = {
  mode: 'development',
  devServer: {
    port: 3002,
    historyApiFallback: true
  },
  output: {
    uniqueName: 'HELP',
    publicPath: 'auto',
    filename: '[name].js',
    chunkFilename: '[name][chunkhash].js'
  },
  module: {
    rules: [
      {
        test: /\.js?$/,
        exclude: /node_modules/,
        loader: 'babel-loader',
        options: {
          presets: [
            '@babel/preset-env',
            '@babel/preset-react',
          ],
                    plugins: [
                        '@babel/plugin-transform-runtime'
                    ]
        },
      },
      {
        test: /\.css$/i,
        use: ["style-loader", "css-loader"],
      },
    ],
  },
  plugins: [
    new ModuleFederationPlugin(
      {
        name: 'HELP',
        filename: 'remoteEntry.js',
        exposes: {
          './App': './src/App',
          './Test': './src/Test'
        },    
        shared: [
          {
            ...deps,
            'react': { requiredVersion: deps.react, singleton: true },
            'react-dom': {
              requiredVersion: deps['react-dom'],
              singleton: true,
            },
            'react-router-dom': {
              requiredVersion: deps['react-router-dom'],
              singleton: true,
          },
          },
        ],
      }
    ),
    new HtmlWebpackPlugin({
      template:
        './public/index.html',
      chunks: ["main"]
    }),
  ],
};